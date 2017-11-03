/**
 * Contains the JavaScript to be used in the _CustomersGrid.cshtml partial view
 * Attaches a button to each grid row and handles the click event on that button
 * @dependencies: jQuery, mvc-grid.js
 * @param {function} jQuery
 */
var customersGridModule = (function (jQuery) {
    if (typeof jQuery === 'undefined') {
        throw new Error('jQuery is not found.');
    }

    /* function declarations */
    var createButton,
        addButtonsToGrid,
        gridIsEmpty,
        viewCustomerButtonClickHandler,
        getCustomerAjaxCall,
        initiliazieModule;

    /* variables */
    var getCustomerUrl = '/Home/GetCustomer',
        viewCustomerButtonId = 'view-customer-button',
        viewCustomerButtonClass = 'btn btn-success',
        viewCustomerButtonText = 'View';

    /* cached DOM object */
    var $container = $('#customers-grid-container');

    /**
    * Creates a button on a grid row
    */
    createButton = function () {
        var viewCustomersButton = document.createElement('button');

        viewCustomersButton.setAttribute('class', viewCustomerButtonClass);
        viewCustomersButton.setAttribute('id', viewCustomerButtonId);
        viewCustomersButton.innerHTML = viewCustomerButtonText;

        $(this).append(viewCustomersButton);
    }

    /**
    * Itterates over the grid rows and attaches them a button with an event handler
    */
    addButtonsToGrid = function () {
        $('.mvc-grid tbody tr').each(function (index, currentGridRow) {
            if (gridIsEmpty(currentGridRow)) {
                return false;
            }

            createButton.call(currentGridRow);

            viewCustomerButtonClickHandler(currentGridRow);
        });
    }

    /**
    * Checks if the grid is empty.
    * If the grid is empty there would be a single row with a text 'No data found'
    * @param {DOM object} gridRow
    */
    gridIsEmpty = function (gridRow) {
        if (gridRow.innerText.indexOf('No data found') !== -1) {
            return true;
        }

        return false;
    }

    /**
    * Attaches a click handler on the give grid row
    * @param {DOM object} grid row to attach event to
    */
    viewCustomerButtonClickHandler = function (currentGridRow) {
        $(currentGridRow).off('click').on('click', function (event) {
            var clickedElementId = event.target.id;

            if (clickedElementId === viewCustomerButtonId) {
                var customerId = $(currentGridRow).find('td.customer-id').html();

                getCustomerAjaxCall(customerId).done(function (result) {
                    $container.html(result);
                });
            }
        });
    }

    /**
    * Makes a GET Ajax request to: getCustomerUrl
    * @param {string} customerId
    * @returns {Function} ajax get function
    */
    getCustomerAjaxCall = function(customerId) {
        var ajaxCall = $.ajax({
            url: getCustomerUrl,
            data: { customerId: customerId },
            type: 'GET',
            dataType: 'html',
            async: true
        });

        return ajaxCall;
    }

    /**
    * Initializes the module
    */
    initiliazieModule = function () {
        addButtonsToGrid();
    }

    return {
        init: initiliazieModule
    }

})(jQuery || {});

customersGridModule.init();