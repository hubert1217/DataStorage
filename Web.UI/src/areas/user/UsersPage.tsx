import { useEffect } from "react";
import UsersTable from "./components/UsersTable";
import { useAppDispatch } from "../../hooks/useAppDispatch";
import userActions from "../../store/user/actions";

const UsersPage = () => {
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(userActions.getAll());
  }, [dispatch]);
  return (
    <>
      <UsersTable />
    </>
  );
};

export default UsersPage;
