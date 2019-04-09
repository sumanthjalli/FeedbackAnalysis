var curremtDomain = 'http://localhost:57194',
    productList,
    FA,
    categories,
    companiesList,
    featureIdList,
    RPProductFeedBackDetails,
    CompitatorsFeedBackDetails = [];
$(document).ready(DOMLoaded);

function DOMLoaded() {

    var feedbackCmplTmpl = _.template($("#tmpl-charts").html()),
        feedbackForm = $('#bs-example'),
        feedbackHtml = '';

    $.ajax({
        url: curremtDomain + "/api/Products/GetProductFeedbackAnalysis?v=" + Date.now(),
        type: "get",
        dataType: "json",
        success: function(response) {
            FA = response;
            //FA = [{ "productName": "Leasing and Renting", "categoryDesc": "Additional Features Needed", "posCnt": 50.0, "negCnt": 50.0, "totalCnt": 100.0, "productId": 1, "categoryId": 4 }, { "productName": "Leasing and Renting", "categoryDesc": "Ease Of Use", "posCnt": 0.0, "negCnt": 100.0, "totalCnt": 100.0, "productId": 1, "categoryId": 1 }, { "productName": "Leasing and Renting", "categoryDesc": "Others", "posCnt": 50.0, "negCnt": 50.0, "totalCnt": 100.0, "productId": 1, "categoryId": 6 }, { "productName": "Leasing and Renting", "categoryDesc": "Product Requirements", "posCnt": 100.0, "negCnt": 0.0, "totalCnt": 100.0, "productId": 1, "categoryId": 2 }, { "productName": "Leasing and Renting", "categoryDesc": "Quality Of support ", "posCnt": 0.0, "negCnt": 100.0, "totalCnt": 100.0, "productId": 1, "categoryId": 3 }, { "productName": "Leasing and Renting", "categoryDesc": "Suggestions", "posCnt": 0.0, "negCnt": 100.0, "totalCnt": 100.0, "productId": 1, "categoryId": 5 }, { "productName": "One Site ", "categoryDesc": "Additional Features Needed", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 2, "categoryId": 4 }, { "productName": "One Site ", "categoryDesc": "Ease Of Use", "posCnt": 0.0, "negCnt": 100.0, "totalCnt": 100.0, "productId": 2, "categoryId": 1 }, { "productName": "One Site ", "categoryDesc": "Others", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 2, "categoryId": 6 }, { "productName": "One Site ", "categoryDesc": "Product Requirements", "posCnt": 0.0, "negCnt": 100.0, "totalCnt": 100.0, "productId": 2, "categoryId": 2 }, { "productName": "One Site ", "categoryDesc": "Quality Of support ", "posCnt": 0.0, "negCnt": 100.0, "totalCnt": 100.0, "productId": 2, "categoryId": 3 }, { "productName": "One Site ", "categoryDesc": "Suggestions", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 2, "categoryId": 5 }, { "productName": "Accounting", "categoryDesc": "Additional Features Needed", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 3, "categoryId": 4 }, { "productName": "Accounting", "categoryDesc": "Ease Of Use", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 3, "categoryId": 1 }, { "productName": "Accounting", "categoryDesc": "Others", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 3, "categoryId": 6 }, { "productName": "Accounting", "categoryDesc": "Product Requirements", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 3, "categoryId": 2 }, { "productName": "Accounting", "categoryDesc": "Quality Of support ", "posCnt": 0.0, "negCnt": 100.0, "totalCnt": 100.0, "productId": 3, "categoryId": 3 }, { "productName": "Accounting", "categoryDesc": "Suggestions", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 3, "categoryId": 5 }, { "productName": "Student Housing ", "categoryDesc": "Additional Features Needed", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 4, "categoryId": 4 }, { "productName": "Student Housing ", "categoryDesc": "Ease Of Use", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 4, "categoryId": 1 }, { "productName": "Student Housing ", "categoryDesc": "Others", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 4, "categoryId": 6 }, { "productName": "Student Housing ", "categoryDesc": "Product Requirements", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 4, "categoryId": 2 }, { "productName": "Student Housing ", "categoryDesc": "Quality Of support ", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 4, "categoryId": 3 }, { "productName": "Student Housing ", "categoryDesc": "Suggestions", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 4, "categoryId": 5 }, { "productName": "Utility Invoice Processing ", "categoryDesc": "Additional Features Needed", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 5, "categoryId": 4 }, { "productName": "Utility Invoice Processing ", "categoryDesc": "Ease Of Use", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 5, "categoryId": 1 }, { "productName": "Utility Invoice Processing ", "categoryDesc": "Others", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 5, "categoryId": 6 }, { "productName": "Utility Invoice Processing ", "categoryDesc": "Product Requirements", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 5, "categoryId": 2 }, { "productName": "Utility Invoice Processing ", "categoryDesc": "Quality Of support ", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 5, "categoryId": 3 }, { "productName": "Utility Invoice Processing ", "categoryDesc": "Suggestions", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 5, "categoryId": 5 }, { "productName": "Spend Management ", "categoryDesc": "Additional Features Needed", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 6, "categoryId": 4 }, { "productName": "Spend Management ", "categoryDesc": "Ease Of Use", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 6, "categoryId": 1 }, { "productName": "Spend Management ", "categoryDesc": "Others", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 6, "categoryId": 6 }, { "productName": "Spend Management ", "categoryDesc": "Product Requirements", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 6, "categoryId": 2 }, { "productName": "Spend Management ", "categoryDesc": "Quality Of support ", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 6, "categoryId": 3 }, { "productName": "Spend Management ", "categoryDesc": "Suggestions", "posCnt": 0.0, "negCnt": 0.0, "totalCnt": 0.0, "productId": 6, "categoryId": 5 }];
            categories = getUniQueCategories();
            $.ajax({
                url: curremtDomain + "/api/Products/GetProducts?v=" + Date.now(),
                type: "get",
                dataType: "json",
                success: function(resp) {
                    productList = _.pluck(resp, 'productName');
                    for(var i1=0;i1<productList;i1++){
                        productList[i] = productList[i].trim().toLowerCase();
                    }
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

    $.ajax({
        url: curremtDomain + "/api/Products/GetProductFeedBackDetails?featureId=2&v=" + Date.now(),
        type: "get",
        dataType: "json",
        success: function(response) {
            RPProductFeedBackDetails = response;
            featureIdList = _.uniq(_.pluck(RPProductFeedBackDetails, 'featureID'));
            for (var i = 0; i < featureIdList.length; i++) {
                $.ajax({
                    url: curremtDomain + "/api/Products/GetCompitatorsFeedBackDetails?featureId=" + featureIdList[i] + "&v=" + Date.now(),
                    type: "get",
                    dataType: "json",
                    async: false,
                    success: function(i, response) {
                        CompitatorsFeedBackDetails.push({
                            featureId: featureIdList[i],
                            data: response
                        });
                        // if (i === featureIdList.length -1) {
                        //     renderFeatureChart();
                        // }
                    }.bind(this, i),
                    error: function(xhr, status) {
                        alert("error");
                    }
                });
            }
            renderFeatureChart();
        },
        error: function(xhr, status) {
            alert("error");
        }
    });

    function renderFeatureChart() {
        var FeaturesNames = [];
        var companiesNames = [];
        var feedBackCategoryNames = [],
            rating = [[]];

        for (var i = 0; i < featureIdList.length; i++) {

            var currentCompitatorsFeedBackDetails = _.filter(CompitatorsFeedBackDetails, { featureId: featureIdList[i] })[0];

            var companies = [];
            companiesNames = [];
            companies.push(_.pluck(currentCompitatorsFeedBackDetails.data, 'companyName'));
            for (var j = 0; j < companies[0].length; j++) {
                companiesNames.push(companies[0][j]);
            }

            companiesNames = _.uniq(companiesNames);

            FeaturesNames.push(_.first(_.filter(RPProductFeedBackDetails, {
                featureID: featureIdList[i]
            })).featureName);

            feedBackCategoryNames = _.pluck(_.filter(RPProductFeedBackDetails, { featureID: featureIdList[i] }), 'categoryDesc');

            var fList = _.filter(RPProductFeedBackDetails, { featureID: featureIdList[i] });
            for (var z = 0; z < feedBackCategoryNames.length; z++) {
                rating[z] = [];
                rating[z].push(_.pluck(_.filter(fList, { categoryDesc: feedBackCategoryNames[z] }), 'rating')[0]);

                for (var j = 0; j < companiesNames.length; j++) {
                    _.pluck(_.filter(currentCompitatorsFeedBackDetails.data, { categoryDesc: feedBackCategoryNames[z] }), 'rating').forEach(function(val, i) {
                        rating[z].push(val);
                    });
                }
            }


            feedbackHtml += feedbackCmplTmpl({
                product: {
                    featureName: FeaturesNames[i],
                    Features: featureIdList,
                    companiesNames: companiesNames,
                    feedBackCategoryNames: feedBackCategoryNames,
                    rating: rating
                }
            });
        }
        feedbackForm.html(feedbackHtml);
    }


    function getUniQueCategories() {
        var category = [];
        FA.forEach(function(val, i) {
            if (!category.includes(val.categoryDesc)) { //&& val.categoryDesc !== "Others"
                category.push(val.categoryDesc);
            }
        });
        return category;
    }



    function renderChart() {

        var data1 = [
            []
        ];
        //     [9, 7, 8],
        //     [14, 10, 11],
        //     [9, 11, 12],
        //     [8, 6, 9],
        //     [9, 11, 12]
        // ];
        var catLen = categories.length,
            j = 0;


        FA.forEach(function(val, i) {
            var ind = productList.indexOf(val.productName);
            if (data1[ind] === undefined) {
                data1[ind] = [];
            }
            if (val.totalCnt == 0) {
                data1[ind][j % catLen] = 0;
            } else {
                data1[ind][j % catLen] = 10;
            }
            j++;
        });



        // data1 = [
        //     [10, 10, 10, 10, 10, 10],
        //     [0, 10, 0, 10, 10, 10],
        //     [10, 10, 10, 10, 10, 10],
        //     [10, 10, 10, 10, 10, 10],
        //     [10, 10, 10, 10, 10, 10],
        // ];

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
                keyColors: ['rgba(255,0,0,0.75)', 'rgba(0,255,0,0.75)'],
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
                labelsAboveSpecific: ['A', 'B', 'C', 'D', 'E', 'F', 'A', 'B', 'C', 'D', 'E', 'F', 'A', 'B', 'C', 'D', 'E', 'F', 'A', 'B', 'C', 'D', 'E', 'F', 'A', 'B', 'C', 'D', 'E', 'F', 'A', 'B', 'C', 'D', 'E', 'F']
            }
        }).on('draw', function(obj) {
            var a = [];

            for (var i = 0; i < FA.length; i++) {
                // if (FA[i].categoryId === 6) {
                //     continue;
                // }
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
                                [a[index].n, a[index].p]
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