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

function Filter() {
    var self = this;

    self.Name = ko.observable("");    
    self.HasNextPage = ko.observable(false);
    self.PageIdx = ko.observable(1);
    self.PageSize = ko.observable(5);    
}

function HomeViewModel(filter) {
    var self = this;
      
    self.Filter = filter;

    self.EmployeeSales = ko.observableArray([]);        

    self.FirstPage = function () {
        self.Filter.PageIdx(1);
        self.Load();
    };

    self.Prev = function () {
        var currentPage = self.Filter.PageIdx();
        if (currentPage > 1) {
            self.Filter.PageIdx(currentPage - 1);
            self.Load();
        }
    };

    self.Next = function () {
        var currentPage = self.Filter.PageIdx();
        if (self.Filter.HasNextPage()) {            
            self.Filter.PageIdx(currentPage + 1);
            self.Load()
        }
    };
    
    self.ApplySearch = function () {    
        if (self.Filter.Name()) {
            self.Filter.PageIdx(1);
            self.Load();
        }        
    };

    self.ClearSearch = function () {
        self.Filter.Name("");
    };

    self.Filter.Name.subscribe(function (newValue) {
        if (!newValue) {
            self.ClearSearch();
            self.Filter.PageIdx(1);
            self.Load();
        }
    });

    self.Load = function () {
        $.ajax(
            {
                url: 'api/home/search', 
                type: "POST",
                data: self.Filter
            }).done(function (data) {                
                var mapped = ko.mapping.fromJS(data, employeeSalesMapping);
                self.EmployeeSales(mapped.EmployeeSales());
                self.Filter.HasNextPage(data.HasMore);
            });
    };    

    self.Init = function () {
        self.Load();
    };

    self.Init();
}

$(function () { ko.applyBindings(new HomeViewModel(new Filter())); });