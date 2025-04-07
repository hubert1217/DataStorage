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
