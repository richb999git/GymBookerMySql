
function buttonClick() {
    // id="spinner1" class="show" or hidden
    var firstItem = document.getElementById("spinner1");
    firstItem.className = "show spinner-centre";
    console.log("make spinner visible");
    return false;
};

document.addEventListener('DOMContentLoaded', function () {
    var firstItem = document.getElementById("spinner1");
    //firstItem.className = "invisible text-center";
    firstItem.className = "invisible spinner-centre";
    console.log("make spinner invisible");
}, false);

window.addEventListener('beforeunload', function () {
    var firstItem = document.getElementById("spinner1");
    firstItem.className = "show spinner-centre";
    console.log("make spinner visible onbeforeunload");
    return false;
}, false);


document.addEventListener('DOMContentLoaded', function () {
    var dateFormat = 'DD-MM-YYYY hh:mm a';
    
    $('.datetimepicker1').datetimepicker({
        format: dateFormat
    });

    // need this due an issue with validation checking
    try {
        $.validator.methods.date = function (value, element) {
            return this.optional(element) || moment(value, dateFormat, true).isValid();
        }
    }
    catch (err) { } // no action if no date entry on page

});

document.addEventListener('DOMContentLoaded', function () {

    $(".hover-drop").hover(
        function () { $(this).addClass('open'); },
        function () { $(this).removeClass('open'); }
    );

});


///////////////////////////////////////////////////////////
// AJAX calls to various database routes

// POST
function CancelClassAJAX(id) {
    
    var xmlHttp = GetHttp();

    if (xmlHttp != null) {
        xmlHttp.onreadystatechange = function () {
            //alert(xmlHttp.readyState);
            if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {
                //alert(xmlHttp.responseText);
                cancElFull = id + "full-C";
                cancElMob = id + "mob-C";
                cancElFullBut = id + "full-CBut";
                cancElMobBut = id + "mob-CBut";
                document.getElementById(cancElFull).textContent = "Cancelled!";
                document.getElementById(cancElMob).textContent = "Cancelled!";
                document.getElementById(cancElMobBut).textContent = "Book Class";
                document.getElementById(cancElFullBut).textContent = "Book Class";
                document.getElementById(cancElMobBut).setAttribute("onclick", "BookClassAJAX(" + id + ")");
                document.getElementById(cancElFullBut).setAttribute("onclick", "BookClassAJAX(" + id + ")"); 
                showToast("Class cancelled");
            }
        }

        // if using GET use it like this:
        //xmlHttp.open("GET", "CalendarItems/CancelClassAJAX/" + id, true);
        //xmlHttp.send();

        //Pass the id and antiforgerytoken into body
        xmlHttp.open("POST", "CalendarItems/CancelClass", true);
        xmlHttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded; charset=utf-8");
        var token = $("[name='__RequestVerificationToken']").val();
        xmlHttp.send("__RequestVerificationToken=" + token + "&id=" + id + "&AJAX=true");
    }
} 


// POST
function BookClassAJAX(id) {
    
    var xmlHttp = GetHttp();

    if (xmlHttp != null) {
        xmlHttp.onreadystatechange = function () {
            if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {
                cancElFull = id + "full-C";  // full screen
                cancElMob = id + "mob-C";    // mobile screen
                cancElFullBut = id + "full-CBut";
                cancElMobBut = id + "mob-CBut";
                document.getElementById(cancElFull).textContent = "You're in!";
                document.getElementById(cancElMob).textContent = "You're in!";
                document.getElementById(cancElMobBut).textContent = "Cancel";
                document.getElementById(cancElFullBut).textContent = "Cancel";
                document.getElementById(cancElMobBut).setAttribute("onclick", "CancelClassAJAX(" + id + ")");
                document.getElementById(cancElFullBut).setAttribute("onclick", "CancelClassAJAX(" + id + ")");
                showToast("Class booked");
            }
        }

        //Pass the id and antiforgerytoken into body
        
        xmlHttp.open("POST", "CalendarItems/BookClass", true);
        xmlHttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded; charset=utf-8");
        var token = $("[name='__RequestVerificationToken']").val();
        xmlHttp.send("__RequestVerificationToken=" + token + "&id=" + id + "&AJAX=true");
    }
}


// POST
// Delete line from members table of booked classes
function MemberCancelClassAJAX(id) {

    var xmlHttp = GetHttp();

    if (xmlHttp != null) {
        xmlHttp.onreadystatechange = function () {
            if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {
                document.getElementById(id).remove();
                showToast("Class cancelled");
            }
        }

        // Pass the id and antiforgerytoken into body  
        xmlHttp.open("POST", "CancelClass", true);
        xmlHttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded; charset=utf-8");
        var token = $("[name='__RequestVerificationToken']").val();
        xmlHttp.send("__RequestVerificationToken=" + token + "&id=" + id + "&AJAX=true");
    }
} 


// POST
// Delete line from members table of booked classes
function StdTimetableDeleteClassAJAX(id) {
    var c = document.getElementById(id).childNodes;
    var desc = "Are you sure you want to delete this class: <span class='text-primary'>" + c[1].textContent + " - " + c[15].textContent + "  " + c[17].textContent + "</span></p>";

    $("#myModal .modal-body").html(desc);
    options = {};
    $('#myModal').modal(options);

    $('#myModal').on('hide.bs.modal', function (e) {
        var tmpId = $(document.activeElement).attr('id');

        if (tmpId == "yes") {
            var xmlHttp = GetHttp();
            if (xmlHttp != null) {
                xmlHttp.onreadystatechange = function () {
                    if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {
                        document.getElementById(id).remove();
                        showToast("Class deleted");
                    }
                }

                //Pass the id and antiforgerytoken into body  
                xmlHttp.open("POST", "StdGymClassTimetables/Delete", true);
                xmlHttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded; charset=utf-8");
                var token = $("[name='__RequestVerificationToken']").val();
                xmlHttp.send("__RequestVerificationToken=" + token + "&id=" + id + "&AJAX=true");
            }
        }
    });

} 


function GetHttp() {

    var xmlHttp = null;

    if (window.XMLHttpRequest) {
        //for new browsers    
        xmlHttp = new XMLHttpRequest();
        return xmlHttp
    }
    else if (window.ActiveXObject) {
        //for old ones    
        var strName = "Msxml2.XMLHTTP"
        if (navigator.appVersion.indexOf("MSIE 5.5") >= 0) {
            strName = "Microsoft.XMLHTTP"
        }
        try {
            xmlHttp = new ActiveXObject(strName);
            return xmlHttp;
        }
        catch (e) {
            alert("Error. Scripting for ActiveX might be disabled")
            return false;
        }
    }
}


//////////////////////////////////////////////////////////////////////////////////////////////////////////
// TOAST

function showToast(message) {
    // Get the snackbar DIV
    var x = document.getElementById("snackbar");

    // add text to snackbar
    x.textContent = message;

    // Add the "show" class to DIV
    x.className = "show";

    // After 3 seconds, remove the show class from DIV
    setTimeout(function () { x.className = x.className.replace("show", ""); }, 1500);
} 
