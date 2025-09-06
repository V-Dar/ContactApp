import RowTableContact from "./components/RowTableContact";


const TableContact = (props) => {
  return (
    <table className="table table-hover table-bordered">
      <thead>
        <tr>
          <th>#</th>
          <th>Имя контакта</th>
          <th>E-mail</th>
        </tr>
      </thead>
      <tbody>
        {
          props.contacts.map(
            contact =>
              <RowTableContact
                id={contact.id}
                name={contact.name}
                email={contact.email}
                deleteContact={props.deleteContact}>
              </RowTableContact>
          )
        }
      </tbody>
    </table>
  )
}
export default TableContact;