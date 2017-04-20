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

    self.HasNextPage = ko.observable(false);
    self.PageIdx = ko.observable(1);
    
}

function HomeViewModel(searchFilter, filter) {
    var self = this;

    const pageSize = 5;

    self.SearchFilter = searchFilter;
    self.Filter = filter;

    self.EmployeeSales = ko.observableArray([]);    
    
    self.EmployeeSalesFiltered = ko.computed(function () {
        var startIdx = (self.Filter.PageIdx() - 1) * pageSize;
        var endIdx = startIdx + pageSize;

        if (endIdx >= self.EmployeeSales().length) {
            self.Filter.HasNextPage(false);
            endIdx = self.EmployeeSales().length;
        } else {
            self.Filter.HasNextPage(true);
        }
        
        return self.EmployeeSales().slice(startIdx, endIdx);        
    });

    self.FirstPage = function () {
        self.Filter.PageIdx(1);
    };

    self.Prev = function () {
        var currentPage = self.Filter.PageIdx();
        if (currentPage > 1) {
            self.Filter.HasNextPage(true);
            self.Filter.PageIdx(currentPage - 1);
        }
    };

    self.Next = function () {
        var currentPage = self.Filter.PageIdx();
        if (self.Filter.HasNextPage()) {
            self.Filter.HasNextPage(false);
            self.Filter.PageIdx(currentPage + 1);
        }
    };
    
    self.ApplySearch = function () {    
        if (self.SearchFilter.Name()) {
            self.Filter.PageIdx(1);
            self.Load();
        }        
    };

    self.ClearSearch = function () {
        self.SearchFilter.Name("");
    };

    self.SearchFilter.Name.subscribe(function (newValue) {
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