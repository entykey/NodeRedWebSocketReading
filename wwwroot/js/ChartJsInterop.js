window.ChartJsInterop = {
    SetupChart: function (chartId, config) {
        const ctx = document.getElementById(chartId).getContext('2d');
        window[chartId] = new Chart(ctx, config);
        console.log(`Chart initialized with ID: ${chartId}`, config);
    },
    UpdateChart: function (chartId, config) {
        console.log(`Updating chart: ${chartId} with new config`, config);
        const chart = window[chartId];
        if (chart) {
            console.log(`Updating chart: ${chartId} with new data`, config.Data);
            chart.data.labels = config.Data.Labels; // Update labels
            chart.data.datasets[0].data = config.Data.Datasets[0].Data; // Update dataset
            console.log(`Updating chart: ${chartId} with new dataset`, chart.data.datasets[0].data);
            chart.update();
            console.log(`Chart ${chartId} updated successfully.`);
        } else {
            console.error(`Chart with ID ${chartId} not found.`);
        }
    }    
};



// window.ChartJsInterop = {
//     SetupChart: function (chartId, config) {
//         const ctx = document.getElementById(chartId).getContext('2d');
//         window[chartId] = new Chart(ctx, config);
//         console.log(`Chart initialized with ID: ${chartId}`, config);
//     },
//     UpdateChart: function (chartId, config) {
//         const chart = window[chartId];
//         if (chart) {
//             console.log(`Updating chart: ${chartId} with new data`, config.Data);
//             chart.data = config.Data; // Update the data correctly
//             chart.update();
//             console.log(`Chart ${chartId} updated successfully.`);
//         } else {
//             console.error(`Chart with ID ${chartId} not found.`);
//         }
//     }
// };
