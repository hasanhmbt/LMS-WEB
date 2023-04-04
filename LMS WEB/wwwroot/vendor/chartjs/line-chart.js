function makeLineChart() {

    //const datapoints = [20, 0, 60, 60, 120, 100, 180, 120, 125, 105, 110, 170];

    const areaData = {
        labels: areaLabels, //["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
        datasets: [
            {
                label: 'Total',
                data: areaDataSet,
                borderColor: 'red',
                fill: false,
                cubicInterpolationMode: 'monotone',
                tension: 0.4
            }
        ]
    };

    const areaConfig = {
        type: 'line',
        data: areaData,
        options: {
            responsive: true,
            plugins: {
                title: {
                    display: false
                },
                legend: {
                    display: false
                }
            },
            interaction: {
                intersect: false,
            },

            scales: {
                x: {
                    display: true,
                    title: {
                        display: true
                    }
                },
                y: {
                    display: true,
                    title: {
                        display: true,
                        text: 'Totals'
                    }
                    //,
                    //suggestedMin: -10,
                    //suggestedMax: 200
                }
            }
        },
    };


    // Line Chart Example
    var ctx = document.getElementById("myAreaChart");
    myLineChart = new Chart(ctx, areaConfig);
}