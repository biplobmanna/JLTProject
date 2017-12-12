function showDivHome() {
    $("#divHome").show();
    $("#divViewJobs").hide();
    $("#divAddJobs").hide();
    $("#divJobApplicants").hide();
}

function showDivViewJobs() {
    $("#divViewJobs").show();
    $("#divAddJobs").hide();
    $("#divHome").hide();
    $("#divJobApplicants").hide();
}

function showDivAddJobs() {
    $("#divAddJobs").show();
    $("#divHome").hide();
    $("#divViewJobs").hide();
    $("#divJobApplicants").hide();
}

function showDivJobApplicants() {
    $("#divAddJobs").hide();
    $("#divHome").hide();
    $("#divViewJobs").hide();
    $("#divJobApplicants").show();
}

$("#ListItemHome").click(() => {
    showDivHome();
});

$("#ListItemViewJobs").click(() => {
    showDivViewJobs();
});

$("#ListItemAddJobs").click(() => {
    showDivAddJobs();
});

$(document).ready(() => {
    var str = $("#LabelHidden").text();
    if (str == "divViewJobs")
        showDivViewJobs();
    else if (str == "divAddJobs")
        showDivAddJobs();
    else if (str == "divJobApplicants") {
        showDivJobApplicants();
        $("#LabelHidden").text("divViewJobs");
    } else
        showDivHome();
});



