var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http, $filter, $timeout) {
    debugger;
    var date = new Date();
    var associateid_tech = 0;
    $scope.t_Specialization;
    $scope.Associatespzfilter;
    //  alert($filter('date')(new Date(), 'MM/dd/yyyy'));

    //cancelactionall
    $scope.cancelactionall = function () {
        $scope.specializationName = "";
        $scope.specializationDesc = "";


        $('#displayfade').hide(); $('#formdisplay').hide();
        document.getElementById("btnSave").setAttribute("value", "Submit");
        document.getElementById("btnSave").className = "btn btn-success modal-close";
    };
    var inputChangedPromise;
    $scope.inputChanged = function () {
        if (inputChangedPromise) {
            $timeout.cancel(inputChangedPromise);
        }
        inputChangedPromise = $timeout(ohk(), 1000);
    }
    //Get_All_Associatefilter
    function ohk()
    {
       
        $scope.Associatespzfilter = {};
        $scope.Associatespzfilter.Specialization_name = $scope.bynamefilter;
        if ($scope.ddlSpecilization == null) {
            $scope.Associatespzfilter.Specialization_ID = 0;
        }
        else {
            $scope.Associatespzfilter.Specialization_ID = $scope.ddlSpecilization.Specialization_ID;
        }
        $http({
            method: "post",
            url: "http://localhost:3063/Associate/Tech_viewgetassociatedataS",
            datatype: "json",
            data: JSON.stringify($scope.Associatespzfilter)
        }).then(function (response) {
              $scope.Associatees = response.data;
        }, function () {
            alert("Error Occur");
        })


    }
    $scope.cancelactionallassociate = function () {
        $scope.AssociateName = "";
        $scope.AssociatePhone = "";
        $scope.AssociateAddress = "";
        for (var i = 0; i < $scope.t_Specialization.length; i++) {
              $scope.t_Specialization[i].Selected = false;
               

            
        }

        $('#displayfade').hide(); $('#formdisplay').hide();
        document.getElementById("btnSave").setAttribute("value", "Submit");
        document.getElementById("btnSave").className = "btn btn-success modal-close";
    };
    $scope.InsertData = function () {
        
      
        if ($scope.AssociateName == "" || $scope.AssociateName == undefined || $scope.AssociatePhone == undefined || $scope.AssociatePhone == "" || $scope.AssociateAddress == "" || $scope.AssociateAddress == undefined) {
            alert('fill all details of associate');
        }
        else {
            var Action = document.getElementById("btnSave").getAttribute("value");
            if (Action == "Submit") {
                var count = 0;
                var message;
                for (var i = 0; i < $scope.t_Specialization.length; i++) {
                    if ($scope.t_Specialization[i].Selected) {
                        count = count + 1;
                        break;
                    }
                }
                if (count > 0) {
                    $scope.Associate = {};
                    $scope.Associate.Associate_Name = $scope.AssociateName;
                    $scope.Associate.Associate_Phone = $scope.AssociatePhone;
                    $scope.Associate.Associate_address = $scope.AssociateAddress;

                    $scope.Associate.Associate_Active = "1";
                    $scope.Associate.Associate_Crby = "1"

                    $scope.Associate.Associate_Crdate = $filter('date')(new Date(), 'MM/dd/yyyy');
                    var associateid;
                    $http({
                        method: "post",
                        url: "http://localhost:3063/Associate/Insert_Associate",
                        datatype: "json",
                        data: JSON.stringify($scope.Associate)
                    }).then(function (response) {

                        associateid_tech = response.data;
                        ohk();
                        $scope.AssociateName = "";
                        $scope.AssociatePhone = "";
                        $scope.AssociateAddress = "";
                        for (var i = 0; i < $scope.t_Specialization.length; i++) {
                            if ($scope.t_Specialization[i].Selected) {


                                $scope.Associatespecilz = {};
                                $scope.Associatespecilz.Associate_ID = associateid_tech;
                                $scope.Associatespecilz.Specialization_ID = $scope.t_Specialization[i].Specialization_ID;

                                $scope.Associatespecilz.Associate_Specialization_Active = "1";
                                $scope.Associatespecilz.Associate_Specialization_Crby = "1"

                                $scope.Associatespecilz.Associate_Specialization_Crdate = $filter('date')(new Date(), 'MM/dd/yyyy');


                                $http({
                                    method: "post",
                                    url: "http://localhost:3063/Associate/Insert_Associate_specialization",
                                    datatype: "json",
                                    data: JSON.stringify($scope.Associatespecilz)
                                }).then(function (response) {

                                })

                            }
                        }
                    })

                    alert('Associate Inserted with their specialization.');

                    $('#displayfade').hide(); $('#formdisplay').hide();
                }
                else {
                    alert('Please select at least one specilization.');
                }

            }
            else {
                var count = 0;
                var message;
                for (var i = 0; i < $scope.t_Specialization.length; i++) {
                    if ($scope.t_Specialization[i].Selected) {
                        count = count + 1;
                        break;
                    }
                }
                if (count > 0) {
                    $scope.Associate = {};
                    $scope.Associate.Associate_Name = $scope.AssociateName;
                    $scope.Associate.Associate_Phone = $scope.AssociatePhone;
                    $scope.Associate.Associate_address = $scope.AssociateAddress;

                    $scope.Associate.Associate_Active = "1";
                    $scope.Associate.Associate_Crby = "1"

                    $scope.Associate.Associate_Crdate = $filter('date')(new Date(), 'MM/dd/yyyy');

                    $scope.Associate.Associate_ID = document.getElementById("AssociateID_").value;
                    $http({
                        method: "post",
                        url: "http://localhost:3063/Associate/Update_Associate",
                        datatype: "json",
                        data: JSON.stringify($scope.Associate)
                    }).then(function (response) {
                        // alert(response.data);
                        ohk();
                        $scope.AssociateName = "";
                        $scope.AssociatePhone = "";
                        $scope.AssociateAddress = "";

                        $scope.Associatedelspz = {};
                        $scope.Associatedelspz.Associate_ID = document.getElementById("AssociateID_").value;

                        $http({
                            method: "post",
                            url: "http://localhost:3063/Associate/Delete_Associatespecialization",
                            datatype: "json",
                            data: JSON.stringify($scope.Associatedelspz)
                        }).then(function (response) {
                            // alert(response.data);
                            for (var i = 0; i < $scope.t_Specialization.length; i++) {
                                if ($scope.t_Specialization[i].Selected) {


                                    $scope.Associatespecilz = {};
                                    $scope.Associatespecilz.Associate_ID = document.getElementById("AssociateID_").value;
                                    $scope.Associatespecilz.Specialization_ID = $scope.t_Specialization[i].Specialization_ID;

                                    $scope.Associatespecilz.Associate_Specialization_Active = "1";
                                    $scope.Associatespecilz.Associate_Specialization_Crby = "1"

                                    $scope.Associatespecilz.Associate_Specialization_Crdate = $filter('date')(new Date(), 'MM/dd/yyyy');


                                    $http({
                                        method: "post",
                                        url: "http://localhost:3063/Associate/Insert_Associate_specialization",
                                        datatype: "json",
                                        data: JSON.stringify($scope.Associatespecilz)
                                    }).then(function (response) {

                                    })

                                }
                            }
                            alert('Associate Updated Successfully.');
                            $('#displayfade').hide(); $('#formdisplay').hide();
                            document.getElementById("btnSave").setAttribute("value", "Submit");
                            document.getElementById("btnSave").className = "btn btn-success modal-close";
                        }, function () {
                            alert("Error Occur");
                        })




                    })
                }
                else {
                    alert('Please select at least one specilization.');
                }
            }
        }
    }
    $scope.Get_All_Associate = function () {
      
        $http({
            method: "get",
            url: "http://localhost:3063/Associate/Get_All_Associate"
        }).then(function (response) {
            $scope.Associatees = response.data;
        }, function () {
            alert("Error Occur");
        })
    };
    
    $scope.DeleteAssociate = function (Associatedata) {
        $http({
            method: "post",
            url: "http://localhost:3063/Associate/Delete_Associate",
            datatype: "json",
            data: JSON.stringify(Associatedata)
        }).then(function (response) {
            alert(response.data);
            ohk();
        })
    };
    $scope.UpdateAssociate = function (Emp) {
        document.getElementById("AssociateID_").value = Emp.Associate_ID;
       
        $scope.AssociateName = Emp.Associate_Name;
        $scope.AssociatePhone = Emp.Associate_Phone;
        $scope.AssociateAddress = Emp.Associate_address;

        $scope.Associatespzfind = {};
        $scope.Associatespzfind.Associate_ID = Emp.Associate_ID;
        $http({
            method: "post",
            url: "http://localhost:3063/Associate/Get_All_Associatespecialization",
            datatype: "json",
            data: JSON.stringify($scope.Associatespzfind)
        }).then(function (response) {
            $scope.t_SpecializationbyAssociate = response.data;
          
            for (var i = 0; i < $scope.t_Specialization.length; i++) {
                for (var j = 0; j < $scope.t_SpecializationbyAssociate.length; j++) {
                    if ($scope.t_Specialization[i].Specialization_ID == $scope.t_SpecializationbyAssociate[j].Specialization_ID) {
                        $scope.t_Specialization[i].Selected = true;
                    }

                }
            }
        }, function () {
            alert("Error Occur");
        })

       
        $('#displayfade').show(); $('#formdisplay').show();


        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").className = "btn btn-warning";
      //  document.getElementById("spn").innerHTML = "Update Associate Information";
        
    }


    // ---t_Specialization Master---------



    $scope.Get_All_Specilization = function () {

        $http({
            method: "get",
            url: "http://localhost:3063/Associate/Get_All_Specilization"
        }).then(function (response) {
            $scope.t_Specialization = response.data;
        }, function () {
            alert("Error Occur");
        })
    };

    $scope.InsertDataspecialization = function () {
        if ($scope.specializationName == "" || $scope.specializationName == undefined || $scope.specializationDesc == undefined || $scope.specializationDesc == "") {
            alert('fill all details!!');
        }
        else {
            var Action = document.getElementById("btnSave").getAttribute("value");
            if (Action == "Submit") {


                $scope.Associatesplmaster = {};
                $scope.Associatesplmaster.Specialization_name = $scope.specializationName;
                $scope.Associatesplmaster.Specialization_Desc = $scope.specializationDesc;

                $scope.Associatesplmaster.Specialization_active = "1";
                $scope.Associatesplmaster.Specialization_crby = "1"

                $scope.Associatesplmaster.Specialization_crdate = $filter('date')(new Date(), 'MM/dd/yyyy');
                var associateid;
                $http({
                    method: "post",
                    url: "http://localhost:3063/Associate/Insert_specialization",
                    datatype: "json",
                    data: JSON.stringify($scope.Associatesplmaster)
                }).then(function (response) {

                    alert(response.data);
                    $scope.Get_All_Specilization();
                    $scope.specializationName = "";
                    $scope.specializationDesc = "";
                })



                $('#displayfade').hide(); $('#formdisplay').hide();


            }
            else {


                $scope.Associatesplmaster = {};
                $scope.Associatesplmaster.Specialization_name = $scope.specializationName;
                $scope.Associatesplmaster.Specialization_Desc = $scope.specializationDesc;

                $scope.Associatesplmaster.Specialization_active = "1";
                $scope.Associatesplmaster.Specialization_crby = "1"

                $scope.Associatesplmaster.Specialization_crdate = $filter('date')(new Date(), 'MM/dd/yyyy');

                $scope.Associatesplmaster.Specialization_ID = document.getElementById("spectID_").value;
                $http({
                    method: "post",
                    url: "http://localhost:3063/Associate/Update_Specializatio",
                    datatype: "json",
                    data: JSON.stringify($scope.Associatesplmaster)
                }).then(function (response) {
                    alert(response.data);
                    $scope.Get_All_Specilization();
                    $scope.specializationName = "";
                    $scope.specializationDesc = "";


                    $('#displayfade').hide(); $('#formdisplay').hide();
                    document.getElementById("btnSave").setAttribute("value", "Submit");
                    document.getElementById("btnSave").className = "btn btn-success modal-close";
                }, function () {
                    alert("Error Occur");
                })






            }
        }
    }

    $scope.Deletespecializatio = function (Associatedata) {
        $http({
            method: "post",
            url: "http://localhost:3063/Associate/Delete_Specializatio",
            datatype: "json",
            data: JSON.stringify(Associatedata)
        }).then(function (response) {
            alert(response.data);
            $scope.Get_All_Specilization();
        })
    };
    $scope.Updatespecializatio = function (Emp) {
        document.getElementById("spectID_").value = Emp.Specialization_ID;

        $scope.specializationName = Emp.Specialization_name;
        $scope.specializationDesc = Emp.Specialization_Desc;


        $('#displayfade').show(); $('#formdisplay').show();


        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").className = "btn btn-warning";
        //  document.getElementById("spn").innerHTML = "Update Associate Information";

    }

})
