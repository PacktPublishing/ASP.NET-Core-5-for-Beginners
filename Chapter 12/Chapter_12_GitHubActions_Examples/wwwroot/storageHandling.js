function SetLocalStorage(key, value) {
    if (key == null) {
        console.error("SetLocalStorage called without supplying a key value.");
    }

    if (localStorage.getItem(key) != null) {
        console.warn("Replacing local storage value with key:" + key);
    }

    localStorage.setItem(key, value);
}

function GetLocalStorage(key) {
    console.debug("GetLocalStorage called for key:" + key);

    return localStorage.getItem(key);
}

function SetSessionStorage(key, value) {
    sessionStorage.setItem(key, value);
}

function GetSessionStorage(key) {
    return sessionStorage.getItem(key);
}