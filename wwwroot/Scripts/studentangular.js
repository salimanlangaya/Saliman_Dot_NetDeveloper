var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http, $filter, $timeout) {
    

    $scope.GetAllClass = function () {

        $http({
            method: "get",
            url: "/api/StudentList/GetAllClass"
        }).then(function (response) {
           
            $scope.GetAllClasslist = response.data; 

        }, function () {
                alert("Error Occur Get Classes");
        })
    };

    $scope.GetAllSubject = function () {

        $http({
            method: "get",
            url: "/api/StudentList/GetAllSubject"
        }).then(function (response) {
            $scope.GetAllSubjectlist = response.data;
        }, function () {
            alert("Error Occur Get Subjects");
        })
    };
    $scope.GetallstudentListfilter = function () {

        $scope.Studentnew = {};
        $scope.Studentnew.StudentID = $scope.ddlSubject;
        $scope.Studentnew.ClassID = $scope.ddlClass;
        $http({
            method: "post",
            //url: "/StudentFront/GetallstudentListfilter",     
            //datatype: "json",
            //data: JSON.stringify($scope.Studentnew)
            url: "/api/StudentList/GetallstudentListfilter",
            params: { 'classid': $scope.ddlClass, 'subid': $scope.ddlSubject }

       
        }).then(function (response) {
            $scope.GetallstudentList_Split = response.data;
        }, function () {
            alert("Error Occur Get Subjects");
        })
    };
    $scope.GetallstudentList = function () {

        $http({
            method: "get",
            url: "/api/StudentList/GetallstudentList"
        }).then(function (response) {
            $scope.GetallstudentList_Split = response.data;
        }, function () {
            alert("Error Occur Get Subjects");
        })
    };
    $scope.GetAllStudent = function (stid,classid,subid) {

        $http({
            method: "get",
            url: "/api/StudentList/GetAllStudent",
            data: { stid:stid, classid:classid, subid:subid}
        }).then(function (response) {
            $scope.studentlistall = response.data;
        }, function () {
            alert("Error Occur");
        })
    };
    $scope.cancelactionInUp = function () {
        $scope.FirstName = "";
        $scope.LasttName = "";
        $scope.Marks = "";
        $scope.ddlClassin = "";
        for (var i = 0; i < $scope.GetAllSubjectlist.length; i++) {
            $scope.GetAllSubjectlist[i].Selected = false;
        }

        $('#displayfade').hide(); $('#formdisplay').hide();
        document.getElementById("btnSave").setAttribute("value", "Submit");
        document.getElementById("btnSave").className = "btn btn-success modal-close";
    };
    
    $scope.InsertData = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.Studentnew = {};
            $scope.Studentnew.FirstName = $scope.FirstName;
            $scope.Studentnew.LastName = $scope.LastName;
            $scope.Studentnew.ClassID = $scope.ddlClassin;
            $http({
                method: "post",
                url: "/api/StudentList/AddStudent",
                datatype: "json",
                data: JSON.stringify($scope.Studentnew)
            }).then(function (response) {
               
               
                StudentIDCurr= response.data;
                for (var i = 0; i < $scope.GetAllSubjectlist.length; i++) {
                    if ($scope.GetAllSubjectlist[i].Selected) {


                        $scope.studentsubjob = {};
                        $scope.studentsubjob.StudentID = StudentIDCurr;
                        $scope.studentsubjob.SubjectID = $scope.GetAllSubjectlist[i].SubjectID;

                        $scope.studentsubjob.Marks = $scope.GetAllSubjectlist[i].Marks;
                       
                        $http({
                            method: "post",
                            url: "/api/StudentList/AddStudentsubj",
                            datatype: "json",
                            data: JSON.stringify($scope.studentsubjob)
                        }).then(function (response) {
                          
                        })

                    }
                }
                $scope.GetallstudentList();
                alert("Student Details added sucessfully");
                $scope.cancelactionInUp();
               
            })
        }
        else {
            $scope.Studentnew = {};
            $scope.Studentnew.FirstName = $scope.FirstName;
            $scope.Studentnew.LastName = $scope.LastName;
            $scope.Studentnew.ClassID = $scope.ddlClassin;
            $scope.Studentnew.StudentID = Number(document.getElementById("StudentID_").value);
          
            $http({
                method: "post",
                url: "/api/StudentList/UpdateStudent",
                datatype: "json",
                data: JSON.stringify($scope.Studentnew)
            }).then(
                function (response) {
                    var msg = response.data;
                   
                $http({
                    method: "put",
                    url: "/api/StudentList/delstdsubjcet",
                    datatype: "json",
                    data: JSON.stringify($scope.Studentnew)
                }).then(function (response) {

                })
                for (var i = 0; i < $scope.GetAllSubjectlist.length; i++) {
                    if ($scope.GetAllSubjectlist[i].Selected) {


                        $scope.studentsubjob = {};
                        $scope.studentsubjob.StudentID = Number(document.getElementById("StudentID_").value);
                        $scope.studentsubjob.SubjectID = $scope.GetAllSubjectlist[i].SubjectID;

                        $scope.studentsubjob.Marks = $scope.GetAllSubjectlist[i].Marks;

                        $http({
                            method: "post",
                            url: "/api/StudentList/AddStudentsubj",
                            datatype: "json",
                            data: JSON.stringify($scope.studentsubjob)
                        }).then(function (response) {

                        })

                    }
                    }
                    $scope.GetallstudentList();
                $scope.cancelactionInUp();
                   
                    alert(msg);
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Student";
            })
        }
    }
    $scope.RemoveStudent = function (studentrem) {
        $scope.Studentnew = {};
        $scope.Studentnew.StudentID = studentrem;
        $scope.Studentnew.FirstName =".";
        $scope.Studentnew.LastName = ".";
        $scope.Studentnew.ClassID = 1;
        $http({
            method: "put",
            url: "/api/StudentList/RemoveStudent",
            datatype: "json",
            data: JSON.stringify($scope.Studentnew)
        }).then(function (response) {
            alert(response.data);
            $scope.GetallstudentList();
            
        })
    };
    $scope.FillUpdateDetails = function (studentup) {    

        document.getElementById("StudentID_").value = studentup.StudentID;
      //  alert(studentup.ClassID);
        $scope.FirstName = studentup.FirstName;
        $scope.LastName = studentup.LastName;
        $scope.ddlClassin = studentup.ClassID;

        $scope.student_sub = {};
        $scope.student_sub.StudentID = studentup.StudentID;
        var stid = studentup.StudentID
      
        $scope.Studentnew = {};
        $scope.Studentnew.StudentID = stid;
        $http({
            method: "post",
            //url: "/api/StudentList/GetallSubjectofStudent1",
            url: "/StudentFront/Get_All_studsubject",
            //datatype: "json",
            //params: JSON.stringify($scope.Studentnew)      
            params: { 'studentid': stid }

           
        }).then(function (response) {
            $scope.student_Subj_DB = response.data;
            for (var i = 0; i < $scope.GetAllSubjectlist.length; i++) {
                for (var j = 0; j < $scope.student_Subj_DB.length; j++) {
                    if ($scope.GetAllSubjectlist[i].SubjectID == $scope.student_Subj_DB[j].SubjectID) {
                        $scope.GetAllSubjectlist[i].Selected = true;
                        $scope.GetAllSubjectlist[i].Marks = $scope.student_Subj_DB[j].Marks;
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
 
})