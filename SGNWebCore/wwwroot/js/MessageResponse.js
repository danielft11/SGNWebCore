class MessageResponse {

    constructor() {
        this._status;
        this._message;
    }

    getStatus() {
        return this._status;
    }

    setStatus(s) {
        this._status = s;
    }

    getMessage() {
        return this._message;
    }

    setMessage(m) {
        this._message = m;
    }

}