function makeDoughnutChart() {
    const pieData = {
        labels: pieDataLabels, //['Red', 'Orange', 'Yellow'],
        datasets: [
            {
                label: 'Book count',
                data: pieDataSet //[50,70,30],
                //backgroundColor: Object.values(Utils.CHART_COLORS),
            }
        ]
    };



    const pieConfig = {
        type: 'doughnut',
        data: pieData,
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'bottom',
                },
                title: {
                    display: false
                } 
            }
        },
    };

    // Pie Chart Example
    var ctx2 = document.getElementById("myPieChart");
    myPieChart = new Chart(ctx2, pieConfig);
}

