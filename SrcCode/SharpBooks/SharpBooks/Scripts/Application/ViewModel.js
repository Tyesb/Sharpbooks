﻿console.log('onehittaquitta');
var ClickCounterViewModel = function () {

    var self = this;
    this.searchBox = ko.observable(); //ko is the JS object that he knockout js library provies. searchbox = to what got enetere in 
    this.searchResults = ko.observableArray();
    this.bookShelfItems = ko.observableArray();
    this.searchClick = function () {

        $.ajax({
            url: '/api/Search',
            data: { search: this.searchBox() },
            type: 'GET',
            datatType: 'json',
            success: function (data) {
                self.searchResults(data);
            },
            fail: function () {
                alert('something up');
            }

        });
    }
    var self = this;
    this.bookshelfitems = ko.observableArray();

    $.ajax({
        url: 'api/BookShelf',
        data: { search: $('#Search').val() },
        type: 'GET',
        datatType: 'json',
        success: function (data) {
            self.bookshelfitems(data);
            console.log("bread & butter");
        },
        fail: function () {
            alert('something up');
        }

    });
};


ko.applyBindings(new ClickCounterViewModel());