import { Button, Modal } from "react-bootstrap";
import { User } from "../../../store/user/models";


export interface EditUserModalProps {
    showModal: boolean;
    handleClose:() =>void
    user: User | undefined;
}
const EditUserModal =(props: EditUserModalProps) => {


    function saveEditedUser() {
        throw new Error("Function not implemented.");
    }

    return(<>
        <Modal
            show={props.showModal}
            onHide={props.handleClose}
            backdrop="static"
            centered
            scrollable={false}
        >
            <Modal.Header>
                <Modal.Title>{props.user?.id}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                {props.user?.firstName} {props.user?.lastName}
            </Modal.Body>
            <Modal.Footer>
                <Button variant='danger' onClick={()=>{props.handleClose()}}></Button>
                <Button variant='danger' onClick={()=>{saveEditedUser()}}></Button>
            </Modal.Footer>
        </Modal>
    </>);



}

export default EditUserModal;