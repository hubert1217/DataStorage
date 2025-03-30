import { Table } from "react-bootstrap";
import { useAppDispatch } from "../../../hooks/useAppDispatch";
import userSelectors from "../../../store/user/selectors";
import { useAppSelector } from "../../../hooks/useAppSelector";
import {
  ColumnDef,
  flexRender,
  getCoreRowModel,
  useReactTable,
} from "@tanstack/react-table";
import { User } from "../../../store/user/models";
import { useMemo } from "react";

const UsersTable = () => {
  const dispatch = useAppDispatch();

  const users = useAppSelector((state) => userSelectors.selectUsers(state));

  console.log("Tutaj");
  console.log(users);

  const columns = useMemo<ColumnDef<User, any>[]>(() => {
    return [
      {
        id: "FirstName",
        accessorFn: (info) => info.firstName,
        header: (info) => <b>FirstName</b>,
      },
      {
        id: "LastName",
        accessorFn: (info) => info.lastName,
        header: (info) => <b>LastName</b>,
      },
      {
        id: "Description",
        accessorFn: (info) => info.description,
        header: (info) => <b>Description</b>,
      },
      {
        id: "Email",
        accessorFn: (info) => info.email,
        header: (info) => <b>Email</b>,
      },
    ];
  }, [users]);

  const table = useReactTable<User>({
    data: users,
    columns,
    getCoreRowModel: getCoreRowModel(),
  });

  return (
    <Table striped bordered hover>
      <thead>
        {table.getHeaderGroups().map((headerGroup, key) => {
          return (
            <tr key={headerGroup.id}>
              {headerGroup.headers.map((header, i) => {
                return (
                  <th>
                    {flexRender(
                      header.column.columnDef.header,
                      header.getContext()
                    )}
                  </th>
                );
              })}
            </tr>
          );
        })}
      </thead>
      <tbody>
        {table.getRowModel().rows.map((row) =>(
            <tr key={row.id}>
                {row.getVisibleCells().map((cell)=>( 
                    <td key={cell.id}>
                        {flexRender(cell.column.columnDef.cell, cell.getContext())}
                    </td>
                ))}
            </tr>
        )
    )}
      </tbody>
    </Table>
  );
};

export default UsersTable;
