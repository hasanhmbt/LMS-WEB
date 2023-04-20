function makeLineChart() {
    const areaLabels = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
    const areaData = {
        labels: areaLabels,
        datasets: [
            {
                label: 'Total',
                data: [0, 0, 8, 1,0,0,0,0,0],
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
                        display: true,
                        text: 'Months'
                    }
                },
                y: {
                    display: true,
                    title: {
                        display: true,
                        text: 'Totals'
                    },
                    suggestedMin: 0,
                    suggestedMax: 50
                }
            }
        },
    };

    // Line Chart Example
    var ctx = document.getElementById("myAreaChart");
    myLineChart = new Chart(ctx, areaConfig);
}
