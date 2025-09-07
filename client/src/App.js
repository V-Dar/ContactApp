import axios from "axios";
import FormContact from "./layout/FormContact/FormContact";
import TableContact from "./layout/tableContact/TableContact";
import { useState, useEffect, useSyncExternalStore } from "react";

const baseApiUrl = process.env.REACT_APP_API_URL;
const App = () => {
  const [contacts, setContacts] = useState([]
  );

  const url = `${baseApiUrl}/contacts`;
  useEffect(() => {
    axios.get(url)
      .then(response =>
        setContacts(response.data)
      );
  }, []);

  const addContact = (contactName, contactEmail) => {
    const newid = contacts.length > 0 ? Math.max(...contacts.map(t => t.id)) + 1 : 1
    const item = {
      id: newid,
      name: contactName,
      email: contactEmail
    };

    const url = `${baseApiUrl}/createContact`;
    console.log(item.id);
    axios.post(url, item);
    setContacts([...contacts, item]); // создаем новый массив на основе старого + новый элемент
  }

  const deleteContact = (id) => {
    const url = `${baseApiUrl}/deleteContacts/${id}`;
    axios.delete(url);
    setContacts(contacts.filter(t => t.id !== id));
  }


  return (
    <div className="container mt-5">
      <div className="card">
        <div className="card-header">
          <h1>Список контактов</h1>
        </div>
        <div className="card-body">
          <TableContact
            contacts={contacts}
            deleteContact={deleteContact}>
          </TableContact>
          <FormContact addContact={addContact} />
        </div>
      </div>
    </div>
  );
}

export default App;
