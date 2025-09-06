import { useState } from "react";

const FormContact = (props) => {
    const [contactName, setContactName] = useState("");
    const [contactEmail, setContactEmail] = useState("");
    const submit = () => {
        if (contactName.trim() === "" || contactEmail.trim() === "") {
            return;
        }
        props.addContact(contactName, contactEmail);
        setContactName("");
        setContactEmail("");
    }
    return (
        <div>
            <div className="mb-3">
                <form>
                    <div className="md-3">
                        <label className="form-label">Введите имя:</label>
                        <input type="text" className="form-control"
                            onChange={(e) => setContactName(e.target.value)}
                            value={contactName}>
                        </input>
                    </div>
                    <div>
                        <label className="form-label">Введите e-mail:</label>
                        <textarea className="form-control" rows="1"
                            onChange={(e) => setContactEmail(e.target.value)}
                            value={contactEmail}>
                        </textarea>
                    </div>
                </form>
            </div>
            <div>
                <button
                    className="btn btn-primary"
                    onClick={() => { submit() }}>
                    Добавить контакт
                </button>
            </div>
        </div>
    );
}
export default FormContact;