/*
 * Created By: Ivor E. Pixabaj
 * Date 22/10/2019
 * DFC
 */


//console.log("Testing....Hello Ivor");


//will bind values retrieved from json file to input boxes and create a form view 
function populateFormView($formRow, jsonData) {
    
    /*$formRow.load("/Home/JsonDataTable/",
        function () {
            alert("Loaded stuffy");studentln.duration
        });
   */

    $("#inputQual1").val(jsonData.education_program_data['studentln.qual1']);
    $("#inputLevel").val(jsonData.education_program_data['studentln.level']);
    $("#inputDuration").val(jsonData.education_program_data['studentln.duration']);
    $("#inputCourse").val(jsonData.education_program_data['studentln.course']);
    $("#inputPastSchool").val(jsonData.education_program_data['studentln.pastschool1']);
    $("#inputQualification").val(jsonData.education_program_data['studentln.pastqual1']);
    $("#inputSchool").val(jsonData.education_program_data['studentln.school']);

    let stuLnBorArr = jsonData.education_program_data['Studentln_borr'];

    stuLnBorArr.forEach(function (obj, index) {
        let itemVal = obj['Studentln_borr.itemval'];
        let aidItem = obj[`Studentln_borr.aiditem`];

        $("#StuLnBorrowItemVal").append(` 
                        <input type="text" class="form-control" id="inputStuLn${index}" value="${itemVal}">
                    `);
        $("#StuLnBorrowAidItem").append(`
                        <div class='input-group-prepend'>
                        <span class='input-group-text'>$</span>
                         <input type="text" class="form-control" id="inputStuLn${index}" value="${aidItem}">
                        </div>`);


        //console.log(obj);
    });

    //var minorProfile = jsonData.minor_profile;
    if (jsonData.minor_profile != null) {
        $("#minorProfileHeader").text("Minor Profile");
        
        for(let prop in jsonData.minor_profile) {
            $("#minorProfileRow").append(`
                       <div class="form-group col-md-4">
                         <label for="">${prop}</label>
                         <input type="text" class="form-control" id="" value="${jsonData.minor_profile[prop]}">
                         </div>
                     `);
        }
    }

    //console.log(jsonData.loan_applicant_profile);
    $("#loanAppProfileHeader").text("Loan Applicant Profile");
    let i = 0;
    for (let lnProProp in jsonData.loan_applicant_profile) {
    
        if (typeof jsonData.loan_applicant_profile[lnProProp] !== 'object') {
            $("#loanApplicantProfileRow").append(`
                      <div class="form-group col-md-3">
                        <label for="">${lnProProp}</label>
                        <input type="text" class="form-control" id="" value="${jsonData.loan_applicant_profile[lnProProp]}">
                        </div>
                    `);
        } else {
           
            $("#subLoanAppProfileRow").append(`<div class="form-group col-md-3 labelCol${i}"></div>`);
            $("#subLoanAppProfileRow").append(`<div class="form-group col-md-3 valCol${i}"></div>`);
            $(`.labelCol${i}`).append(`<h6>${lnProProp.toUpperCase()}</h6>`);
            $(`.valCol${i}`).append(`<h6>VAL</h6>`);
 
            jsonData.loan_applicant_profile[lnProProp].forEach(function (item) {
                
                for(let nestedProp in item) {
              
                    $(`.labelCol${i}`).append(`         
                        <input type="text" class="form-control"  value="${nestedProp}">       
                    `);
                    $(`.valCol${i}`).append(`         
                        <input type="text" class="form-control"  value="${item[nestedProp]}">       
                    `);
                    
                }
               
            });
        }
        i++; //increment acts as a identifier for dynamic fields
    }

    //----------------------Guarantor Profile ----------------------------------

    fillGuarantorData(jsonData.guarantors);
    
    //----------------------- Loan Configuration --------------------------------

    fillLoanConfig(jsonData.loan_config);

}
//---------------------------Load Guarantor Data --------------------

function fillGuarantorData(data) {
    let $guarantorRow = $("#guarantorProfileRow");
    
    //checking if file has guarantors and passing values to UI if contains
  
    if (data.length < 1) {
        console.log("has no items");
    } else {
        //if file has guarantors we do the following
         
        $("#guarantorHeader").text(`Guarantor`);
        //let arrObj = [];
        //runs twice
        
        data.forEach(function (item, index) {
            $('#guarantorProfileRow').append(`
                <div class='row row${index}'></div><hr/><hr/>`);
            for (let prop in item) {

                $(`.row${index}`).append(`
                    <div class='col-md-6 ${prop}'>
                        <h5>${prop}</h5>
                        <div class='row' id='${prop}${index}'></div>
                    </div>`);
                for (let i in item[prop]) {
                    if (typeof item[prop][i] !== 'object') {
                        $(`#${prop}${index}`).append(`
                            <div class='col-md-6'>
                                <label>${i}</label>
                                <input type='text' class='form-control' value='${item[prop][i]}'> 
                            </div>`);
                    } else {
                       // $(`#${prop}${index}`).append(``);
                        $(`#${prop}${index}`).append(`<div class='col-md-6'>
                                        <hr/><h6>${i}</h6>
                                       <div class='row' id='sub${i}${index}'></div>
                                    </div>`);
                        //console.log(i);
                        item[prop][i].forEach(function(elem) {
                            for (let j in elem) {
                                $(`#sub${i}${index}`).append(`<div class='col-md-8 form-group'>
                                    <label>${j}</label>
                                    <input type='text' class='form-control' value='${elem[j]}'>
                                    </div>`);
                                //console.log(``);
                            }
                        });
                        
                    }
                }
            }

        });
        //console.log(arrObj);
        
    }
}


//----------------------------load configuration info ---------------

function fillLoanConfig(data) {
    for (let i in data) {
        $('#loanConfigRow').append(`<div class="form-group col-md-4">
            <label for="">${i}</label>
            <input type="text" class="form-control" id="" value="${data[i]}">
            </div>`);
    }
}

//Scroll to top implementation
var btn = $('#regScrollToTop');

$(window).scroll(function () {
    if ($(window).scrollTop() > 20) {
        btn.addClass('show');
    } else {
        btn.removeClass('show');
    }
});

btn.on('click', function (e) {
    e.preventDefault();
    $('html, body').animate({ scrollTop: 0 }, '300');
});