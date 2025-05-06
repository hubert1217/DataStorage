import { Button, Modal, Spinner } from "react-bootstrap";

export interface ConfirmationModalProps {
  message: string;
  isModalLoading: boolean;
  showModal: boolean;
  handleClose: () => void;
  onConfirm: () => void;
}

const ConfirmationModal = (props: ConfirmationModalProps) => {
  return (
    <>
      <Modal
        show={props.showModal}
        onHide={props.handleClose}
        backdrop="static"
        centered
        scrollable={false}
      >
        <Modal.Header>
          <Modal.Title></Modal.Title>
        </Modal.Header>
        <Modal.Body>{props.message}</Modal.Body>
        <Modal.Footer>
          <Button
            className="btn btn-light btn-sm"
            onClick={() => {
              props.handleClose();
            }}
          >
            Close
          </Button>
          <Button
            className="btn btn-primary btn-sm"
            onClick={() => {
              props.onConfirm();
            }}
          >
            {props.isModalLoading ? <Spinner size="sm" /> : "Apply"}
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
};
export default ConfirmationModal;
