/*
 * Created By: Ivor E. Pixabaj
 * Date 22/10/2019
 * DFC
 */
console.log("Hello Ivor");
//will bind values retrieved from json file to input boxes and create a form view 
function populateFormView($formRow, jsonData) {
    /*$formRow.load("/Home/JsonDataTable/",
        function () {
            alert("Loaded stuffy");studentln.duration
        });*/
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

    // console.log(minorProfileArr);
    //console.log(jsonData.loan_applicant_profile);
    $("#loanAppProfileHeader").text("Loan Applicant Profile");

    for (var lnProProp in jsonData.loan_applicant_profile) {
    
        if (typeof jsonData.loan_applicant_profile[lnProProp] !== 'object') {
            $("#loanApplicantProfileRow").append(`
                      <div class="form-group col-md-4">
                        <label for="">${lnProProp}</label>
                        <input type="text" class="form-control" id="" value="${jsonData.loan_applicant_profile[lnProProp]}">
                        </div>
                    `);
        } else {
            $("#subLoanAppProfileRow").append(`<h5>${lnProProp}</h5>`);
            jsonData.loan_applicant_profile[lnProProp].forEach(function (item) {
                for (let nestedProp in item) {
                    console.log(item[nestedProp]);
                    $("#subLoanAppProfColLabel").append(`  
                            <input class="form-control" type='text' value='${nestedProp}'></label>      
                    `);
                    $("#subLoanAppProfColVal").append(`  
                            <input type="text" class="form-control" id="" value="${item[nestedProp]}">                       
                    `);
                }
            });


            // for (let x in jsonData.loan_applicant_profile[prop]) {
            //x[]
            //}
        }
    }
}