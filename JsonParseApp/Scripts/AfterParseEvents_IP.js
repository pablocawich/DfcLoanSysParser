function addCheckBoxListener() {
    //Applicant Id checkbox 
    $("#applicantIdCheckBox").on('change',
        function () {
            var $box = $(this);

            if ($box.is(':checked')) {
                bootbox.confirm({
                    size: 'large',
                    backdrop: true,
                    title: 'Customer Omission',
                    message:
                        "<p>By ticking the checkbox you are confirming that the user exists in the DPAC system. Further approval will trigger an input box where you are to insert the applicant's already established ID. Kindly enter a valid id.</p>",
                    buttons: {
                        confirm: {
                            label: 'Proceed',
                            className: 'btn-success'
                        },
                        cancel: {
                            label: 'Cancel',
                            className: 'btn-danger'
                        }
                    },
                    callback: function (result) {
                        if (result) {
                            $(`#applicantIdBox`).attr('hidden', false);
                        } else {
                            $box.prop("checked", false);
                        }

                    }
                });
            } else {
                $(`#applicantIdBox`).find("input[type=text], textarea").val("");
                $(`#applicantIdBox`).attr('hidden', true);
            }
        });
    //Minor Profile checkbox
    $("#minorProfileIdCheck").on('change',
        function () {
            var $box = $(this);

            if ($box.is(':checked')) {
                bootbox.confirm({
                    size: 'large',
                    backdrop: true,
                    title: 'Customer Omission',
                    message:
                        "<p>By ticking the checkbox you are confirming the existence of the applicant in the DPAC system. Further accepting will trigger an input box where you are to insert the applicant's already established ID. Ensure it's a valid input.</p>",
                    buttons: {
                        confirm: {
                            label: 'Proceed',
                            className: 'btn-success'
                        },
                        cancel: {
                            label: 'Cancel',
                            className: 'btn-danger'
                        }
                    },
                    callback: function (result) {
                        if (result) {
                            $(`#minorIdBox`).attr('hidden', false);
                        } else {
                            $box.prop("checked", false);
                        }

                    }
                });
            } else {
                $(`#minorIdBox`).find("input[type=text], textarea").val("");
                $(`#minorIdBox`).attr('hidden', true);
            }
        });
    //Guarantor check box
    $("#guarantor").on('change',
        ".gridCheck",
        function () {
            var $checkBox = $(this);
            var guarantorNum = $(this).val();
            if ($checkBox.is(':checked')) {
                bootbox.confirm({
                    size: 'large',
                    backdrop: true,
                    title: 'Customer Omission',
                    message:
                        "<p>By ticking the checkbox you are confirming the existence of the applicant in the DPAC system. Further accepting will trigger an input box where you are to insert the applicant's already established ID. Ensure it's a valid input.</p>",
                    buttons: {
                        confirm: {
                            label: 'Proceed',
                            className: 'btn-success'
                        },
                        cancel: {
                            label: 'Cancel',
                            className: 'btn-danger'
                        }
                    },
                    callback: function (result) {
                        if (result) {
                            $(`#applicantIdBox${guarantorNum}`).attr('hidden', false);
                        } else {
                            $checkBox.prop("checked", false);
                        }

                    }
                });
            } else {
                $(`#applicantIdBox${guarantorNum}`).find("input[type=text], textarea").val("");
                $(`#applicantIdBox${guarantorNum}`).attr('hidden', true);
            }
        });
}

function importLoanDataButton() {
    $("#importBtn").on('click',
        function (e) {
            e.preventDefault();

            if (!validateApplicantId())
                bootbox.confirm({
                    backdrop: true,
                    title: 'Confirm Form Submission',
                    message:
                        "The form will be submitted with the data in the given tab. The only exception would be if you have provided an ID for customers, only then will the the data for that section be omitted.",
                    buttons: {
                        confirm: {
                            label: 'Accept and Continue',
                            className: 'btn-success'
                        },
                        cancel: {
                            label: 'Cancel',
                            className: 'btn-danger'
                        }
                    },
                    callback: function (result) {
                        if (result) {
                            $("#loanDataForm").submit();
                        }
                    }
                });
            else {
                alert("Something occured that has rendered the form submission ineligible. Kindly Fix");
            }
        });
}

function importValidateListener() {
    $('.app-id').on('keypress keydown keyup', function () {
        if ($(this).val().length > 10) {
            // there is a mismatch, hence show the error message
            //$('.emssg').removeClass('hidden');
            $(this).parent().next().removeClass('hidden');
            //$(this).parent().next().css({ "color": "blue", "border": "2px solid red","background-color":"yellow" });
            $(this).parent().next().show();          
        }
        else {
            // else, do not display message
            $(this).parent().next().addClass('hidden');
        }
    });
}

function validateApplicantId() {
    var hasErr = false;
    /*$(".app-id").each(function () {
        console.log($(this).val());
    });*/

    $(".app-id").each(function () {
        // alert($(this).val());
        let inputSize = $(this).val().length;

        if (inputSize > 10) {

            alert($(this).val() + " is of length" + $(this).val().length + " is greater than 10");

            hasErr = true;
        }

    });
    // alert(hasErr);
    return hasErr;
}

function validateApplicantIdOnServer() {
    $(".validateBtn").on('click',
        function (e) {
            var $btn = $(this);
            //alert($btn.prev().val());
            var stringId = $btn.prev().val();
          $.ajax({
                type: 'GET',
                url: `/Home/CheckForCustomerInDpac?id=${stringId}`,
                //data: formData,
                dataType: 'json',
                cache: false,
                //enctype: "multipart/form-data",
               // beforeSend: function () {},
                contentType: false,
                processData: false

            }).done(function (response) {
                if (response.success) {
                    $btn.next().html('');
                    $btn.next().append(`<p style="color: green"><i class="fa fa-thumbs-up"></i> Awesome! ID was located. Please ensure <strong>(${response.message})</strong> matches the information below. Once approved, this portion of the loan is eligible for a submit</p>`);
                  //alert(response.message);
                } else {
                    $btn.next().html('');
                    $btn.next().append(`
                       <p><i class="fa fa-exclamation-triangle"></i> ${response.message}</p>`);
                  //alert(response.message);
              }

          });

        });
}