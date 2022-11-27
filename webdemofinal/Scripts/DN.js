function getValue(id) {
    return document.getElementById(id).value.trim();
}
function showError(key, mess) {
    document.getElementById(key + '_error').innerHTML = mess;
}

function Validate() {
    var flag = true;
    var name = getValue('name');
    if (name.length < 5 || name.length > 20) {
        flag = false;
        showError('username', "Nhập trong khoảng từ 5 đến 20 kí tự");
    }
    var phone = getValue('phone');
    if (phone.length != 10 || !/[0-9]/.test(phone)) {
        flag = false;
        showError('Phone', "Số điện thoại bao gồm 10 số");
    }
    return flag;
}
