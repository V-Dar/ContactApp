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

  const addContact = () => {
    const item = {
      id: contacts.sort((x, y) => x.id - y.id)[contacts.length - 1].id + 1,
      name: 'Имя Фамилия4',
      email: "fake4"
    };
    setContacts([...contacts, item]); // создаем новый массив на основе старого + новый элемент
    console.log(contacts);
  }


  return (
    <div className="container mt-5">
      <div className="card">
        <div className="card-header">
          <h1>Список контактов</h1>
        </div>

        <div className="card-body">
          <TableContact contacts={contacts}></TableContact>
          <div>
            <button
              className="btn btn-primary"
              onClick={() => { addContact() }}>
              Добавить контакт
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
