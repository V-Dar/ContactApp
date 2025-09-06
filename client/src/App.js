import FormContact from "./layout/FormContact/FormContact";
import TableContact from "./layout/tableContact/TableContact";
import { useState } from "react";


const App = () => {
  const [contacts, setContacts] = useState(
    [
      { id: 1, name: 'Имя Фамилия1', email: "fake1" },
      { id: 2, name: 'Имя Фамилия2', email: "fake2" },
      { id: 3, name: 'Имя Фамилия3', email: "fake3" }
    ]
  );

  const addContact = (contactName, contactEmail) => {
    const newid = contacts.length > 0 ? Math.max(...contacts.map(t => t.id)) : 1
    const item = {
      id: newid,
      name: contactName,
      email: contactEmail
    };
    setContacts([...contacts, item]); // создаем новый массив на основе старого + новый элемент
    console.log(contacts);
  }

  const deleteContact = (id) => {
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
