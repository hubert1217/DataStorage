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
import EditUserModal from "../Modals/EditUserModal";
import { useAppDispatch } from "../../../hooks/useAppDispatch";
import userActions from "../../../store/user/actions";

const UsersTable = () => {
  const dispatch = useAppDispatch();
  const users = useAppSelector((state) => userSelectors.selectUsers(state));
  const user = useAppSelector((state) => userSelectors.selectUser(state));
  const isUserListLoading = useAppSelector((state) =>
    userSelectors.selectIsUserListLoading(state)
  );
  const [isEditModalOpen, setIsEditModalOpen] = useState(false);

  const handleEdit = (user: User) => {
    setIsEditModalOpen(true);
    dispatch(userActions.selectUser(user as User));
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
        header: "Actions",
        cell: ({ row }) => (
          <div className="d-flex gap-1">
            <button className="btn btn-primary btn-sm" onClick={() => handleEdit(row.original)}>Edit</button>
            <button className="btn btn-danger btn-sm" onClick={() => handleDelete(row.original.id)}>Delete</button>
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
      <EditUserModal
        showModal={isEditModalOpen}
        handleClose={() => setIsEditModalOpen(false)}
        user={user ?? undefined}
      />
    </>
  );
};

export default UsersTable;
