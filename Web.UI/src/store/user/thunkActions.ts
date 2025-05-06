import { createAsyncThunk } from "@reduxjs/toolkit";
import UsersClient from "../../api/UsersClient";

export const getAll = createAsyncThunk("User/getAll", async (thunkApi) => {
  return await UsersClient.getAll();
});

export const update = createAsyncThunk(
  "User/update",
  async (
    {
      id,
      firstName,
      lastName,
      description,
      email,
    }: {
      id: number;
      firstName: string;
      lastName: string;
      description: string;
      email: string;
    },
    thunkApi
  ) => {
    return await UsersClient.update(
      id,
      firstName,
      lastName,
      description,
      email
    );
  }
);

export const add = createAsyncThunk(
  "User/add",
  async (
    {
      firstName,
      lastName,
      description,
      email,
    }: {
      firstName: string;
      lastName: string;
      description: string;
      email: string;
    },
    thunkApi
  ) => {
    return await UsersClient.add(firstName, lastName, description, email);
  }
);

export const deleteUser = createAsyncThunk(
  "User/delete",
  async ({ id }: { id: number }, thunkApi) => {
    await UsersClient.delete(id)
    return id ;
  }
);
