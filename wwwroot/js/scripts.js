$(function () {
    //Main Menu Click Functions
    $(".bossMainMenu").click(function () {
        $(".homeMenuRow").hide();
        $(".sideMenuCol").show();
        $(".bossDisplay").show();
    });
    $(".currentPricesMainMenu").click(function () {
        $(".homeMenuRow").hide();
        $(".sideMenuCol").show();
        $(".currentPricesDisplay").show();
    });
    $(".savedGearMainMenu").click(function () {
        $(".homeMenuRow").hide();
        $(".sideMenuCol").show();
        $(".savedGearDisplay").show();
    });

    //Side Menu Click Functions
    $(".bossSideMenu").click(function () {
        $(".bossName").html("");
        $(".bossGearSets").html("");
        $(".bossGearDisplay").hide();
        $(".savedGearDisplay").hide();
        $(".currentPricesDisplay").hide();
        $(".bossDisplay").show();
    });
    $(".currentPricesSideMenu").click(function () {
        $(".bossName").html("");
        $(".bossGearSets").html("");
        $(".bossGearDisplay").hide();
        $(".bossDisplay").hide();
        $(".savedGearDisplay").hide();
        $(".currentPricesDisplay").show();
    });
    $(".savedGearSideMenu").click(function () {
        $(".bossName").html("");
        $(".bossGearSets").html("");
        $(".bossGearDisplay").hide();
        $(".bossDisplay").hide();
        $(".currentPricesDisplay").hide();
        $(".savedGearDisplay").show();
    });

    //Select Boss To Display Gear Sets
    $(".selectBoss").click(function () {
        $(".bossGearDisplay").show();
        $(".bossDisplay").hide();
        $(".bossGearSets").show();
        //Declare variables for AJAX calls, html strings to append and FSid to hold fullset id's
        var url = $(this).data('request-url');
        var currentId = this.id;
        var bossName = "";
        var htmlString = "";
        var finalString = "";

        //First AJAX call returns the single object arrays
        $.ajax({
            type: 'GET',
            url: url,
            data: { bossId: currentId },
            contentType: 'application/json',
            dataType: 'json',
            success: function (result) {
                for (var v = 0; v < result.bosses.length; v++)
                {
                    if (result.bosses[v].id == result.bossId)
                    {
                        bossName += "<h1>" + result.bosses[v].name + "</h1>";
                    }
                }
                $(".bossName").html(bossName);

                //Second AJAX call returns the join tables
                $.ajax({
                    url: 'Home/GrabJoins',
                    type: 'GET',
                    contentType: 'application/json',
                    dataType: 'json',
                    success: function (data) {
                        for (var i = 0; i < data.fullSetBosses.length; i++)
                        {
                            //If there is a Boss ID in the FullSetBosses join table, grab the FullSet ID and continue
                            if(data.fullSetBosses[i].bossId == result.bossId)
                            {
                                //Set FSid to the FullSet ID that corresponds with the Boss ID
                                var newhtmlString = "";
                                var FSid = data.fullSetBosses[i].fullSetId;
                                var setNameHtmlString = "";

                                //Create a DIV to add the gear related to the FullSet into for posting
                                htmlString += "<div class='gearSet'>";
                                for (var n = 0; n < result.fullSets.length; n++)
                                {
                                    if (result.fullSets[n].id == FSid)
                                    {
                                        //Add SetName to the html
                                        htmlString += "<h3 class='gearSetNameDisplay'><strong>" + result.fullSets[n].setName + "</strong></h3>";
                                    }
                                }


                                //Iterate through the FullSetGears Table to grab all the Gear ID's
                                for (var x = 0; x < data.fullSetGears.length; x++)
                                {
                                    //Iterate through the Gears Table to grab all the gear info if the Gear ID matches the one in the FullSetGears table
                                    for (var y = 0; y < result.gears.length; y++)
                                    {
                                        if(data.fullSetGears[x].fullSetId == FSid && data.fullSetGears[x].gearId == result.gears[y].id)
                                        {
                                            //Create a string of each of the gear pieces information and then concatinate onto the html string
                                            //Add links to Gear Details page to display stats
                                            newhtmlString += "<h5 class='gearPieceDisplay'> <span class='gearSlotDisplay'><strong>" + result.gears[y].slot + ":</strong></span> <span class='gearNameDisplay'>" + result.gears[y].name + "</span> | <span class='gearPriceDisplay'>Price: " + result.gears[y].price + "</h5>";
                                        }
                                    }
                                }
                                htmlString += setNameHtmlString += newhtmlString;
                                htmlString += "</div>";
                                //finalString += htmlString;
                            }
                        }
                        $(".bossGearSets").html(htmlString);
                    }
                });
            }
        });
    });

    $("#get-items").click(function () {
        $(".itemLookup").html("<h2>Please wait while the item is found..</h2>");
        $.ajax({
            url: 'Home/GetPrice',
            type: 'GET',
            dataType: 'json',
            data: { itemName: $("#searchQuery").val() },
            success: function (result) {
                console.log(result);
                $(".itemLookup").html("<h2>" + $("#searchQuery").val() + "</h2><img src='" + result.item.icon_large + "'><h3>" +  result.item.description + "</h3><h3>" + result.item.current.price + "</h3>");
            }
        })
    });
});