debugger;
$(document).ready(function () {
    //$('[data-toggle="tooltip"]').tooltip();

    debugger;
    var submenu;
    $(".vertical-nav-menu li").click(function () {

        var id = $(this).attr("id");
        $('#' + id).siblings().find(".mm-active").removeClass("mm-active");
        $('#' + id).addClass("mm-active");

        localStorage.setItem("selectedolditem", id);
        var test = $(this).children();

        var grandchildren = $(this).children().find(".mm-active").attr("id");

        if (grandchildren != undefined || grandchildren != null) {
            localStorage.setItem("selectedolditemchild", submenu);
        } else {
            localStorage.setItem("selectedolditemchild", null);
            submenu = id;
        }
    });

    var selectedolditem = localStorage.getItem('selectedolditem');
    var selectedolditemchild = localStorage.getItem("selectedolditemchild");

    if (selectedolditem != null) {
        $('#' + selectedolditem).siblings().find(".mm-active").removeClass("mm-active");
        $('#' + selectedolditem).addClass("mm-active");

        if (selectedolditemchild != null) {
            $('#' + selectedolditemchild).siblings().find(".mm-active").removeClass("mm-active");
            $('#' + selectedolditemchild).addClass("mm-active");
        } else {
            $('#' + selectedolditem).children().siblings().find(".mm-active").removeClass("mm-active");

        }

    }

    history.replaceState({}, null, this.location.pathname);
});