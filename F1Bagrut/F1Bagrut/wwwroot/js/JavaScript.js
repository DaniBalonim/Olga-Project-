function CheckUser() {
    var user = document.getElementById("username").value;
    var len = user.length;
    var countSpace = 0;
    var hasDigit = /\d/.test(user);

    if (len === 0) {
        document.getElementById("usernameError").innerHTML = "Please enter a username";
        document.getElementById("usernameError").style.color = "red";
        return false;
    } else {
        for (var i = 0; i < len; i++) {
            if (user[i] === " ") {
                countSpace++;
            }
        }
        if (countSpace > 1) {
            document.getElementById("usernameError").innerHTML = "Only one space is allowed";
            document.getElementById("usernameError").style.color = "red";
            return false;
        }
        else if (!hasDigit) {
            document.getElementById("usernameError").innerHTML = "Username must contain at least one number";
            document.getElementById("usernameError").style.color = "red";
            return false;
        }
        else {
            document.getElementById("usernameError").innerHTML = "";
        }
    }
    return true;
}

function CheckFName() {
    var fName = document.getElementById("fName").value;
    var countSpace = 0;
    var len = fName.length;

    if (len == 0) {
        document.getElementById("errorFname").innerHTML = "Please enter your first name";
        document.getElementById("errorFname").style.color = "red";
        return false;
    } else if (!(fName[0] >= 'A' && fName[0] <= 'Z')) {
        document.getElementById("errorFname").innerHTML = "First letter must be uppercase English";
        document.getElementById("errorFname").style.color = "red";
        return false;
    }
    else if (len < 2) {
        document.getElementById("errorFname").innerHTML = "At least 2 letters";
        document.getElementById("errorFname").style.color = "red";
        return false;
    }
    else {
        var flag = true;
        for (var i = 1; i < len && flag; i++) {
            if (fName[i] === ' ')
                countSpace++;
            else if (!(fName[i] >= 'a' && fName[i] <= 'z' || fName[i] >= 'A' && fName[i] <= 'Z'))
                flag = false;
        }

        if (countSpace > 1) {
            document.getElementById("errorFname").innerHTML = "Only one space is allowed";
            document.getElementById("errorFname").style.color = "red";
            return false;
        } else if (!flag) {
            document.getElementById("errorFname").innerHTML = "Only English letters are allowed";
            document.getElementById("errorFname").style.color = "red";
            return false;
        } else {
            document.getElementById("errorFname").innerHTML = "";
        }
    }
    return true;
}

function CheckLName() {
    var lName = document.getElementById("lName").value;
    var countSpace = 0;
    var len = lName.length;

    if (len === 0) {
        document.getElementById("errorLname").innerHTML = "Please enter your last name";
        document.getElementById("errorLname").style.color = "red";
        return false;
    } else if (!(lName[0] >= 'A' && lName[0] <= 'Z')) {
        document.getElementById("errorLname").innerHTML = "First letter must be uppercase English";
        document.getElementById("errorLname").style.color = "red";
        return false;
    }
    else if (len < 2) {
        document.getElementById("errorLname").innerHTML = "At least 2 letters";
        document.getElementById("errorLname").style.color = "red";
        return false;
    }
    else {
        var flag = true;
        for (var i = 1; i < len && flag; i++) {
            if (lName[i] === ' ')
                countSpace++;
            else if (!(lName[i] >= 'a' && lName[i] <= 'z' || lName[i] >= 'A' && lName[i] <= 'Z'))
                flag = false;
        }

        if (countSpace > 1) {
            document.getElementById("errorLname").innerHTML = "Only one space is allowed";
            document.getElementById("errorLname").style.color = "red";
            return false;
        } else if (!flag) {
            document.getElementById("errorLname").innerHTML = "Only English letters are allowed";
            document.getElementById("errorLname").style.color = "red";
            return false;
        } else {
            document.getElementById("errorLname").innerHTML = "";
        }
    }
    return true;
}

function CheckEmail() {
    var email = document.getElementById("txtEmail").value;
    var errorBox = document.getElementById("emailError");

    if (email.length === 0) {
        errorBox.innerHTML = "Please enter an email address";
        errorBox.style.color = "red";
        return false;
    }

    var allowedDomains = ["@gmail.com", "@yahoo.com"];

    var isValid = false;
    for (var i = 0; i < allowedDomains.length; i++) {
        if (email.endsWith(allowedDomains[i])) {
            isValid = true;
            break;
        }
    }

    if (!isValid) {
        errorBox.innerHTML = "Email must end with a valid domain like @gmail.com  or @yahoo.com ";
        errorBox.style.color = "red";
        return false;
    }

    errorBox.innerHTML = "";
    return true;
}

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

function CheckPassword() {
    var password = document.getElementById("pass1").value;
    var errorBox = document.getElementById("pass1Error");

    if (password.length === 0) {
        errorBox.innerHTML = "Please enter a password";
        errorBox.style.color = "red";
        return false;
    }

    if (password.indexOf(' ') !== -1) {
        errorBox.innerHTML = "Password cannot contain spaces";
        errorBox.style.color = "red";
        return false;
    }

    if (password.length < 8) {
        errorBox.innerHTML = "Password must be at least 8 characters long";
        errorBox.style.color = "red";
        return false;
    }

    var hasLowercase = /[a-z]/.test(password);
    var hasUppercase = /[A-Z]/.test(password);
    var hasDigit = /\d/.test(password);

    if (!hasLowercase || !hasUppercase || !hasDigit) {
        errorBox.innerHTML = "Password must contain at least one uppercase letter, one lowercase letter, and one number, and only english letters";
        errorBox.style.color = "red";
        return false;
    }

    errorBox.innerHTML = "";
    return true;
}

function ConfirmPasswordMatch() {
    var password = document.getElementById("pass1").value;
    var confirmPassword = document.getElementById("pass2").value;
    var errorBox = document.getElementById("pass2Error");

    if (confirmPassword.length === 0) {
        errorBox.innerHTML = "Please confirm your password";
        errorBox.style.color = "red";
        return false;
    }

    if (password !== confirmPassword) {
        errorBox.innerHTML = "Passwords do not match";
        errorBox.style.color = "red";
        return false;
    }

    errorBox.innerHTML = "";
    return true;
}

function CheckBirthDate() {
    var birth = document.getElementById("birth").value;
    var errorBox = document.getElementById("birthError");

    if (birth === "" || birth === "0001-01-01") {
        errorBox.innerHTML = "Please enter a valid birth date";
        errorBox.style.color = "red";
        return false;
    }

    errorBox.innerHTML = "";
    return true;
}

function Gender() {
    var male = document.getElementById("M");
    var female = document.getElementById("F");

    if (!male.checked && !female.checked) {
        document.getElementById("genderError").innerHTML = "Please select one gender";
        document.getElementById("genderError").style.color = "red";
        return false;
    } else {
        document.getElementById("genderError").innerHTML = "";
    }
    return true;
}

function City() {
    var select = document.getElementById("city");
    var place = select.selectedIndex;

    if (place === 0) {
        document.getElementById("cityError").innerHTML = "Please select a country";
        document.getElementById("cityError").style.color = "red";
        return false;
    } else {
        document.getElementById("cityError").innerHTML = "";
    }
    return true;
}

function CheckForm() {
    var valid = true;

    valid = CheckUser() && valid;
    valid = CheckFName() && valid;
    valid = CheckLName() && valid;
    valid = CheckEmail() && valid;
    valid = CheckPassword() && valid;
    valid = confirmPhone() && valid;
    valid = Gender() && valid;
    valid = City() && valid;
    valid = ConfirmPasswordMatch() && valid;
    valid = CheckBirthDate() && valid;

    if (!valid) {
        return false;
    }

    return true; 
}

function clearErrors() {
    document.getElementById("errorFname").innerHTML = "";
    document.getElementById("errorLname").innerHTML = "";
    document.getElementById("errorUser").innerHTML = "";
    document.getElementById("errorPhone").innerHTML = "";
    document.getElementById("errorPassword").innerHTML = "";
    document.getElementById("errorGender").innerHTML = "";
    document.getElementById("errorCountry").innerHTML = "";
    document.getElementById("errorColor").innerHTML = "";
    document.getElementById("formErrorMessage").style.display = "none";
}
