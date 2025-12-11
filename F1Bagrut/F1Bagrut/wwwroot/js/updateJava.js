function confirmPhone() {
    var phone = document.getElementById("phone").value;
    var msgBox = document.getElementById("phoneError");

    var reg = /^0(2|3|4|6|8|9|5[2-8]|73)[1-9]\d{6}$/;
    var len = phone.length;

    if (len === 0) {
        msgBox.innerHTML = "Please enter a phone number";
        msgBox.style.color = "red";
        return false;
    } else if (!reg.test(phone)) {
        msgBox.innerHTML = "Invalid phone number";
        msgBox.style.color = "red";
        return false;
    }

    msgBox.innerHTML = "";
    return true;
}