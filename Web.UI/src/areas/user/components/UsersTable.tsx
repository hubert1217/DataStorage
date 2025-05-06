import { Spinner, Table } from "react-bootstrap";
import userSelectors from "../../../store/user/selectors";
import { useAppSelector } from "../../../hooks/useAppSelector";
import {
  ColumnDef,
  flexRender,
  getCoreRowModel,
  getSortedRowModel,
  useReactTable,
} from "@tanstack/react-table";
import { User } from "../../../store/user/models";
import { useMemo, useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faSort,
  faSortDown,
  faSortUp,
} from "@fortawesome/free-solid-svg-icons";
import { useAppDispatch } from "../../../hooks/useAppDispatch";
import userActions from "../../../store/user/actions";
import UpsertUserModal from "../Modals/UpsertUserModal";
import ConfirmationModal from "../../shared/Modal/ConfirmationModal";

const UsersTable = () => {
  const dispatch = useAppDispatch();
  const users = useAppSelector((state) => userSelectors.selectUsers(state));
  const user = useAppSelector((state) => userSelectors.selectUser(state));
  const isDeleteUserLoading = useAppSelector((state) => userSelectors.selectIsDeleteUserLoading(state));
  const isUserListLoading = useAppSelector((state) =>
    userSelectors.selectIsUserListLoading(state)
  );
  const [isUpsertModalOpen, setIsUpsertModalOpen] = useState(false);
  const [isDeleteConfirmationModalOpen, setIsDeleteConfirmationModalOpen] = useState(false);
  const [deleteUser, setDeleteUser] = useState<User|null>(null);
  const handleDelete = (user: User) => {
    setDeleteUser(user);
    setIsDeleteConfirmationModalOpen(true)
  };

  const handleUpsert = (user: User | undefined) => {
    setIsUpsertModalOpen(true);
    dispatch(userActions.selectUser(user));
  };

  const columns = useMemo<ColumnDef<User, any>[]>(() => {
    return [
      {
        id: "FirstName",
        accessorFn: (info) => info.firstName,
        header: ({ column }) => <b>{column.id}</b>,
      },
      {
        id: "LastName",
        accessorFn: (info) => info.lastName,
        header: ({ column }) => <b>{column.id}</b>,
      },
      {
        id: "Description",
        accessorFn: (info) => info.description,
        header: ({ column }) => <b>{column.id}</b>,
      },
      {
        id: "Email",
        accessorFn: (info) => info.email,
        header: ({ column }) => <b>{column.id}</b>,
      },
      {
        id: "Actions",
        header: () => (
          <div>
            <b>Action</b>
            <button
              onClick={() => handleUpsert(undefined)}
              className="btn btn-light btn-sm ms-3"
            >
              Add new user
            </button>
          </div>
        ),
        // header: "Actions",
        cell: ({ row }) => (
          <div className="d-flex gap-1">
            <button
              className="btn btn-primary btn-sm"
              onClick={() => handleUpsert(row.original)}
            >
              Edit
            </button>
            <button
              className="btn btn-danger btn-sm"
              onClick={() => handleDelete(row.original)}
            >
              Delete
            </button>
          </div>
        ),
        enableSorting: false,
      },
    ];
  }, [users]);

  const table = useReactTable<User>({
    data: users,
    columns,
    getCoreRowModel: getCoreRowModel(),
    getSortedRowModel: getSortedRowModel(),
  });

  return (
    <>
      <Table striped bordered hover>
        <thead>
          {table.getHeaderGroups().map((headerGroup) => {
            return (
              <tr key={headerGroup.id}>
                {headerGroup.headers.map((header) => {
                  return (
                    <th key={header.id}>
                      <div
                        role="button"
                        onClick={() => {
                          if (header.column.getCanSort()) {
                            header.column.toggleSorting();
                          }
                        }}
                        style={{
                          cursor: header.column.getCanSort()
                            ? "pointer"
                            : "default",
                          display: "flex",
                          alignItems: "center",
                        }}
                      >
                        {flexRender(
                          header.column.columnDef.header,
                          header.getContext()
                        )}
                        {header.column.getCanSort() &&
                          (!header.column.getIsSorted() ? (
                            <FontAwesomeIcon icon={faSort} className="px-2" />
                          ) : (
                            {
                              asc: (
                                <FontAwesomeIcon
                                  icon={faSortUp}
                                  className="px-2"
                                />
                              ),
                              desc: (
                                <FontAwesomeIcon
                                  icon={faSortDown}
                                  className="px-2"
                                />
                              ),
                            }[header.column.getIsSorted() as string] ?? null
                          ))}
                      </div>
                    </th>
                  );
                })}
              </tr>
            );
          })}
        </thead>
        {isUserListLoading ? (
          <tr>
            <td
              colSpan={table.getAllColumns().length}
              className="text-center p-4"
            >
              <Spinner />
            </td>
          </tr>
        ) : table.getRowModel().rows.length === 0 ? (
          <tr>
            <td
              colSpan={table.getAllColumns().length}
              className="text-center p-4"
            >
              Table is empty!
            </td>
          </tr>
        ) : (
          <tbody>
            {table.getRowModel().rows.map((row) => (
              <tr key={row.id}>
                {row.getVisibleCells().map((cell) => (
                  <td key={cell.id}>
                    {flexRender(cell.column.columnDef.cell, cell.getContext())}
                  </td>
                ))}
              </tr>
            ))}
          </tbody>
        )}
      </Table>
      <UpsertUserModal
        showModal={isUpsertModalOpen}
        handleClose={() => setIsUpsertModalOpen(false)}
        user={user ?? undefined}
      />
      <ConfirmationModal 
        message={"Are you sure delete record?"} 
        isModalLoading={isDeleteUserLoading} 
        showModal={isDeleteConfirmationModalOpen} 
        handleClose={()=> setIsDeleteConfirmationModalOpen(false)}
        onConfirm={()=>{
          dispatch(userActions.deleteUser({ id: deleteUser?.id! })).then(()=>setIsDeleteConfirmationModalOpen(false));
        }}
      ></ConfirmationModal>
    </>
  );
};

export default UsersTable;
