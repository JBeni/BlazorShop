var BlazorShop = {};

BlazorShop.setSessionStorage = function (key, data) {
    sessionStorage.setItem(key, data);
}

BlazorShop.getSessionStorage = function (key) {
    return sessionStorage.getItem(key);
}

BlazorShop.hideModal = function (element) {
    bootstrap.Modal.getInstance(element).hide();
}
