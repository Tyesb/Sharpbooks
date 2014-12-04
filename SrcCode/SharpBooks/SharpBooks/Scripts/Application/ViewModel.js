console.log('onehittaquitta');
var ClickCounterViewModel = function () {
    this.numberOfClicks = ko.observable(0);

    this.searchResults = ko.observableArray();
    var self = this;


    this.registerClick = function () {
        this.numberOfClicks(this.numberOfClicks() + 1);
    };

    this.resetClicks = function () {
        this.numberOfClicks(0);
    };

    this.hasClickedTooManyTimes = ko.pureComputed(function () {
        return this.numberOfClicks() >= 3;
    }, this);

    this.searchClick = function () {
        //this.searchResults()
        //   this.numberOfClicks(this.numberOfClicks() + 1);
        $.ajax({
            url: '/api/Search',
            data: { search: $('#Search').val() },
            type: 'GET',
            datatType: 'json',
            success: function (data) {
                self.searchResults(data);
                console.log("bread & butter");
            },
            fail: function () {
                alert('something up');
            }

        });
    }
};


ko.applyBindings(new ClickCounterViewModel());