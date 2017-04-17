var employeeSalesMapping = {
    'EmployeeSales': {
        create: function (options) {
            return new EmployeeSales(options.data);
        }
    }
};

function EmployeeSales(data) {
    ko.mapping.fromJS(data, {}, this);
}

function SearchFilter() {
    var self = this;
    self.Name = ko.observable("");    
}

function Filter() {
    var self = this;
    
}

function HomeViewModel(searchFilter, filter) {
    var self = this;

    self.SearchFilter = searchFilter;
    self.Filter = filter;

    self.EmployeeSales = ko.observableArray([]);

    
    self.ApplySearch = function () {    
        if (self.SearchFilter.Name()) {
            self.Load();
        }        
    };

    self.ClearSearch = function () {
        self.SearchFilter.Name("");
    };

    self.SearchFilter.Name.subscribe(function (newValue) {
        if (!newValue) {
            self.ClearSearch();
            self.Load();
        }
    });

    self.Load = function () {
        $.ajax(
            {
                url: 'api/home/search', 
                type: "POST",
                data: self.SearchFilter
            }).done(function (data) {                
                var mapped = ko.mapping.fromJS(data, employeeSalesMapping);
                self.EmployeeSales(mapped.EmployeeSales());
            });
    };    

    self.Init = function () {
        self.Load();
    };

    self.Init();
}

$(function () { ko.applyBindings(new HomeViewModel(new SearchFilter(), new Filter())); });