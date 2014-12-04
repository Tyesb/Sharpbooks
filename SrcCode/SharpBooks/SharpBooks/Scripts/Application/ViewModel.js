console.log('onehittaquitta');
var ClickCounterViewModel = function () {
    this.searchBox = ko.observable(); //ko is the JS object that he knockout js library provies. searchbox = to what got enetere in 
    this.searchResults = ko.observableArray();
    var self = this;
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
};


ko.applyBindings(new ClickCounterViewModel());