$("#ListItemHome").click(() => {
    $("#divHome").show();
    $("#divViewJobs").hide();
    $("#divAddJobs").hide();
});

$("#ListItemViewJobs").click(() => {
    $("#divViewJobs").show();
    $("#divAddJobs").hide();
    $("#divHome").hide();
});

$("#ListItemAddJobs").click(() => {
    $("#divAddJobs").show();
    $("#divHome").hide();
    $("#divViewJobs").hide();
});

