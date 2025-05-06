import { Button, Form, Modal, Spinner } from "react-bootstrap";
import { User } from "../../../store/user/models";
import { useEffect, useState } from "react";
import userActions from "../../../store/user/actions";
import { useAppDispatch } from "../../../hooks/useAppDispatch";
import { useAppSelector } from "../../../hooks/useAppSelector";
import userSelectors from "../../../store/user/selectors";

export interface UpsertUserModalProps {
  showModal: boolean;
  handleClose: () => void;
  user: User | undefined;
}
const UpsertUserModal = (props: UpsertUserModalProps) => {
  const dispatch = useAppDispatch();
  const [originalUser, setOriginalUser] = useState<User | null>(null);
  const [formData, setFormData] = useState<User | null>(null);

  // const allFieldsEmpty =
  //   formData === null || Object.values(formData).every((value) => value === "");
  const isEdited =
    JSON.stringify(originalUser) !== JSON.stringify(formData);

  const isUpdateUserLoading = useAppSelector((state) =>
    userSelectors.selectIsUpdateUserLoading(state)
  );

  useEffect(() => {
    if (props.user) {
      setOriginalUser(props.user);
      setFormData(props.user);
    } else {
      setOriginalUser(null);
      setFormData(null);
    }
  }, [props.user]);

  const saveEditedUser = () => {
    // dispatch(userActions.update(formData!)).then(()=>{
    //   props.handleClose();
    // });

    dispatch(userActions.update(formData!)).then((action) => {
      if (userActions.update.fulfilled.match(action)) {
        props.handleClose();
      }
    });
  };

  const addUser = () => {
    dispatch(userActions.add(formData!));
  };

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    setFormData((prev) => ({
      ...prev!,
      [name]: value,
    }));
  };

  const cancelChanges = () => {
    setFormData(originalUser);
  };

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
          <Modal.Title>Edit the user {props.user?.id}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form>
            <Form.Group className="mb-3">
              <Form.Label>FirstName</Form.Label>
              <Form.Control
                type="text"
                name="firstName"
                value={formData?.firstName ?? ""}
                onChange={handleChange}
              />
            </Form.Group>

            <Form.Group className="mb-3">
              <Form.Label>LastName</Form.Label>
              <Form.Control
                type="text"
                name="lastName"
                value={formData?.lastName ?? ""}
                onChange={handleChange}
              />
            </Form.Group>
            <Form.Group className="mb-3">
              <Form.Label>Description</Form.Label>
              <Form.Control
                type="text"
                name="description"
                value={formData?.description ?? ""}
                onChange={handleChange}
              />
            </Form.Group>
            <Form.Group className="mb-3">
              <Form.Label>Email</Form.Label>
              <Form.Control
                type="text"
                name="email"
                value={formData?.email ?? ""}
                onChange={handleChange}
              />
            </Form.Group>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          {isEdited ? (
            <Button
              className="btn btn-light btn-sm"
              onClick={() => {
                cancelChanges();
              }}
            >
              Cancel
            </Button>
          ) : (
            <Button
              className="btn btn-light btn-sm"
              onClick={() => {
                props.handleClose();
              }}
            >
              Close
            </Button>
          )}
          <Button
            className="btn btn-primary btn-sm"
            disabled={!isEdited  }
            onClick={() => {
              props.user === undefined ? addUser() : saveEditedUser();
            }}
          >
            {isUpdateUserLoading ? (
              <Spinner size="sm" />
            ) : props.user === undefined ? (
              "Add"
            ) : (
              "Update"
            )}
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
};

export default UpsertUserModal;
