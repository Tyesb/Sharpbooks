console.log('onehittaquitta');
var ClickCounterViewModel = function () {

    this.searchResults = ko.observableArray();
    var self = this;
    this.searchClick = function () {

        $.ajax({
            url: '/api/Search',
            data: { search: $('#Search').val() },
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