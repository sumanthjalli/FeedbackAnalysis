var curremtDomain = 'http://localhost:57194',
    productList,
    FA,
    categories;
$(document).ready(DOMLoaded);

function DOMLoaded() {

    $.ajax({
        url: curremtDomain + "/api/Products/GetProductFeedbackAnalysis?v=" + Date.now(),
        type: "get",
        dataType: "json",
        success: function(response) {
            FA = response;
            FA =  [{ "productName": "Leasing and Renting", "categoryDesc": "Additional Features Needed", "posCnt": 50.0, "negCnt": 50.0, "totalCnt": 100.0, "productId": 1, "categoryId": 4 }, { "productName": "Leasing and Renting", "categoryDesc": "Ease Of Use", "posCnt": 0.0, "negCnt": 100.0, "totalCnt": 100.0, "productId": 1, "categoryId": 1 }, { "productName": "Leasing and Renting", "categoryDesc": "Others", "posCnt": 50.0, "negCnt": 50.0, "totalCnt": 100.0, "productId": 1, "categoryId": 6 }, { "productName": "Leasing and Renting", "categoryDesc": "Product Requirements", "posCnt": 100.0, "negCnt": 0.0, "totalCnt": 100.0, "productId": 1, "categoryId": 2 }, { "productName": "Leasing and Renting", "categoryDesc": "Quality Of support ", "posCnt": 0.0, "negCnt": 100.0, "totalCnt": 100.0, "productId": 1, "categoryId": 3 }, { "productName": "Leasing and Renting", "categoryDesc": "Suggestions", "posCnt": 0.0, "negCnt": 100.0, "totalCnt": 100.0, "productId": 1, "categoryId": 5 }, { "productName": "One Site ", "categoryDesc": "Additional Features Needed", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 2, "categoryId": 4 }, { "productName": "One Site ", "categoryDesc": "Ease Of Use", "posCnt": 0.0, "negCnt": 100.0, "totalCnt": 100.0, "productId": 2, "categoryId": 1 }, { "productName": "One Site ", "categoryDesc": "Others", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 2, "categoryId": 6 }, { "productName": "One Site ", "categoryDesc": "Product Requirements", "posCnt": 0.0, "negCnt": 100.0, "totalCnt": 100.0, "productId": 2, "categoryId": 2 }, { "productName": "One Site ", "categoryDesc": "Quality Of support ", "posCnt": 0.0, "negCnt": 100.0, "totalCnt": 100.0, "productId": 2, "categoryId": 3 }, { "productName": "One Site ", "categoryDesc": "Suggestions", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 2, "categoryId": 5 }, { "productName": "Accounting", "categoryDesc": "Additional Features Needed", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 3, "categoryId": 4 }, { "productName": "Accounting", "categoryDesc": "Ease Of Use", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 3, "categoryId": 1 }, { "productName": "Accounting", "categoryDesc": "Others", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 3, "categoryId": 6 }, { "productName": "Accounting", "categoryDesc": "Product Requirements", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 3, "categoryId": 2 }, { "productName": "Accounting", "categoryDesc": "Quality Of support ", "posCnt": 0.0, "negCnt": 100.0, "totalCnt": 100.0, "productId": 3, "categoryId": 3 }, { "productName": "Accounting", "categoryDesc": "Suggestions", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 3, "categoryId": 5 }, { "productName": "Student Housing ", "categoryDesc": "Additional Features Needed", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 4, "categoryId": 4 }, { "productName": "Student Housing ", "categoryDesc": "Ease Of Use", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 4, "categoryId": 1 }, { "productName": "Student Housing ", "categoryDesc": "Others", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 4, "categoryId": 6 }, { "productName": "Student Housing ", "categoryDesc": "Product Requirements", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 4, "categoryId": 2 }, { "productName": "Student Housing ", "categoryDesc": "Quality Of support ", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 4, "categoryId": 3 }, { "productName": "Student Housing ", "categoryDesc": "Suggestions", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 4, "categoryId": 5 }, { "productName": "Utility Invoice Processing ", "categoryDesc": "Additional Features Needed", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 5, "categoryId": 4 }, { "productName": "Utility Invoice Processing ", "categoryDesc": "Ease Of Use", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 5, "categoryId": 1 }, { "productName": "Utility Invoice Processing ", "categoryDesc": "Others", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 5, "categoryId": 6 }, { "productName": "Utility Invoice Processing ", "categoryDesc": "Product Requirements", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 5, "categoryId": 2 }, { "productName": "Utility Invoice Processing ", "categoryDesc": "Quality Of support ", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 5, "categoryId": 3 }, { "productName": "Utility Invoice Processing ", "categoryDesc": "Suggestions", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 5, "categoryId": 5 }, { "productName": "Spend Management ", "categoryDesc": "Additional Features Needed", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 6, "categoryId": 4 }, { "productName": "Spend Management ", "categoryDesc": "Ease Of Use", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 6, "categoryId": 1 }, { "productName": "Spend Management ", "categoryDesc": "Others", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 6, "categoryId": 6 }, { "productName": "Spend Management ", "categoryDesc": "Product Requirements", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 6, "categoryId": 2 }, { "productName": "Spend Management ", "categoryDesc": "Quality Of support ", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 6, "categoryId": 3 }, { "productName": "Spend Management ", "categoryDesc": "Suggestions", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 6, "categoryId": 5 }];
            categories = getUniQueCategories();
            $.ajax({
                url: curremtDomain + "/api/Products/GetProducts?v=" + Date.now(),
                type: "get",
                dataType: "json",
                success: function(resp) {
                    productList = _.pluck(resp, 'productName');
                    renderChart();
                },
                error: function(xhr, status) {
                    alert("error");
                }
            });
        },
        error: function(xhr, status) {
            alert("error");
        }
    });

    function getUniQueCategories() {
        var category = [];
        FA.forEach(function(val, i) {
            if (!category.includes(val.categoryDesc) && val.categoryDesc !== "Others") {
                category.push(val.categoryDesc);
            }
        });
        return category;
    }



    function renderChart() {

        var data1 = [
            []
        ];
             //[9, 7, 8],
             //[14, 10, 11],
             //[9, 11, 12],
             //[8, 6, 9],
             //[9, 11, 12]
        // ];
        //[10,10,10]
        var catLen = categories.length - 1;


        FA.forEach(function(val, i) {
            if (val.categoryId !== 6) {
                var ind = productList.indexOf(val.productName);
                if (data1[ind] === undefined) {
                    data1[ind] = [];
                }
                data1[ind].push(val.totalCnt);
            }
        });
        data1 = [[10, 10, 10],
            [10, 10, 10],
            [10, 10, 10],
            [10, 10, 10],
            [10, 10, 10]];

        var tooltips = [];

        for (var i = 0; i < 32; i++) {
            tooltips.push([

                'Negative Feedback',
                'Positive Feedback'
            ])
        }

        var bar = new RGraph.SVG.Bar({
            id: 'cc',
            data: data1,
            options: {
                marginTop: 75,
                key: ['Negative feedback', 'Positive feedback'],
                keyColors: ['rgba(255,0,0,0.75)','rgba(0,255,0,0.75)'],
                hmargin: 20,
                hmarginGrouped: 5,
                yaxis: false,
                xaxis: false,
                xaxisLabels: productList,
                colors: ['rgba(0,0,0,0)', 'rgba(0,0,0,0)'],
                title: '',
                titleSubtitle: '',
                titleSubtitleY: '+5',
                labelsAbove: true,
                labelsAboveSize: 8,
                labelsAboveSpecific: ['A', 'B', 'C', 'D', 'E', 'A', 'B', 'C', 'D', 'E', 'A', 'B', 'C', 'D', 'E', 'A', 'B', 'C', 'D', 'E', 'A', 'B', 'C', 'D', 'E', 'A', 'B', 'C', 'D', 'E']
            }
        }).on('draw', function(obj) {
            var a = [];

            for (var i = 0; i < FA.length; i++) {
                if (FA[i].categoryId === 6) {
                    continue;
                }
                a.push({
                    p: FA[i].posCnt,
                    n: FA[i].negCnt
                });
            }

            for (var i = 0; i < obj.coords.length; ++i) {

                (function(index, a) {
                    var coords = obj.coords[index];

                    setTimeout(function() {
                        new RGraph.SVG.Bar({
                            id: 'cc',
                            data: [
                                [a[index].n , a[index].p]
                            ],
                            options: {
                                backgroundGrid: false,
                                colors: ['rgba(255,0,0,0.75)', 'rgba(0,255,0,0.75)'],
                                tooltips: tooltips[index],
                                yaxisScaleMax: 100,
                                hmargin: 0,
                                hmarginGrouped: 0,
                                grouping: 'stacked',
                                yaxis: false,
                                xaxis: false,
                                yaxisScale: false,
                                marginLeft: coords.x,
                                marginRight: obj.width - coords.x - coords.width,
                                marginTop: coords.y,
                                marginBottom: obj.height - coords.y - coords.height
                            }
                        }).grow();
                    }, 50 * index);
                })(i, a);
            }
        }).draw();

        // Some tooltips appearance customisation
        RGraph.SVG.tooltips.style.backgroundColor = 'black';
        RGraph.SVG.tooltips.style.color = 'white';
        RGraph.SVG.tooltips.style.fontWeight = 'bold';
    }


}