function showDivHome() {
    $("#divHome").show();
    $("#divViewJobs").hide();
    $("#divAppliedJobsView").hide();
}

function showDivViewJobs() {
    $("#divHome").hide();
    $("#divViewJobs").show();
    $("#divAppliedJobsView").hide();
}

function showDivAppliedJobsView() {
    $("#divHome").hide();
    $("#divViewJobs").hide();
    $("#divAppliedJobsView").show();
}


//Changing the views for Divisions

$("#ListItemHome").click(() => {
    showDivHome();
});

$("#ListItemViewJobs").click(() => {
    showDivViewJobs();
});

$("#ListItemAppliedJobs").click(() => {
    showDivAppliedJobsView();
});

$(document).ready(() => {
    var str = $("#LabelHidden").text();
    if (str == "divViewJobs")
        showDivViewJobs();
    else if (str == "divAppliedJobsView")
        showDivAppliedJobsView();
    else
        showDivHome();
});