import "./App.scss";
import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import { useAppDispatch } from "../../hooks/useAppDispatch";
import { useEffect } from "react";
import userActions from "../../store/user/actions";
import UsersPage from "../user/UsersPage";

const App = () => {

  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(userActions.getAll());
  },[dispatch])


  return (
    <>
      <Navbar bg="dark" data-bs-theme="dark">
        <Container>
          <Navbar.Brand href="#home">Data Storage</Navbar.Brand>
          <Nav className="me-auto">
            <Nav.Link href="#features">Features</Nav.Link>
            <Nav.Link href="#pricing">Pricing</Nav.Link>
          </Nav>
        </Container>
      </Navbar>
      <UsersPage />
    </>
  );
};

export default App;
