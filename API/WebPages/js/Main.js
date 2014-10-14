function setPage() {
    var pageName = window.location.href;

    if (pageName.indexOf("ListActiveContentRequest.aspx") != -1) {

        document.getElementById("active").className = "selectedPage";
        document.getElementById("archive").className = "unSelectedPage";

        document.getElementById("RManagement").className = "selectedPage";
        document.getElementById("USetting").className = "unSelectedPage";
        document.getElementById("UManagement").className = "unSelectedPage";
    }
    else if (pageName.indexOf("ListArchiveContentRequest.aspx") != -1) {

        document.getElementById("archive").className = "selectedPage";
        document.getElementById("active").className = "unSelectedPage";

        document.getElementById("RManagement").className = "selectedPage";
        document.getElementById("USetting").className = "unSelectedPage";
        document.getElementById("UManagement").className = "unSelectedPage";
    } else if (pageName.indexOf("GetContent.aspx") != -1) {

        if (pageName.indexOf("type=active") != -1) {
            document.getElementById("active").className = "selectedPage";
            document.getElementById("archive").className = "unSelectedPage";
        }
        else {
            document.getElementById("archive").className = "selectedPage";
            document.getElementById("active").className = "unSelectedPage";
        }

        document.getElementById("RManagement").className = "selectedPage";
        document.getElementById("USetting").className = "unSelectedPage";
        document.getElementById("UManagement").className = "unSelectedPage";
    } else if (pageName.indexOf("ListUsers.aspx") != -1 || pageName.indexOf("AddUser.aspx") != -1) {
        document.getElementById("active").style.display = "none";
        document.getElementById("archive").style.display = "none";

        document.getElementById("UManagement").className = "selectedPage";
        document.getElementById("USetting").className = "unSelectedPage";
        document.getElementById("RManagement").className = "unSelectedPage";
    }
    else if (pageName.indexOf("Setting.aspx") != -1) {
        document.getElementById("active").style.display = "none";
        document.getElementById("archive").style.display = "none";

        document.getElementById("USetting").className = "selectedPage";
        document.getElementById("UManagement").className = "unSelectedPage";
        document.getElementById("RManagement").className = "unSelectedPage";
    }
}

//Select all checkbox of Repeator which math with id parameter
function SelectAllCheckboxes(spanChk, id) {
    var oItem = spanChk.children;
    var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
    xState = theBox.checked;
    elm = theBox.form.elements;

    for (i = 0; i < elm.length; i++) {
        if (elm[i].type == "checkbox" && elm[i].name != theBox.name && elm[i].name.match(id)) {
            elm[i].checked = xState;
        }
    }
}