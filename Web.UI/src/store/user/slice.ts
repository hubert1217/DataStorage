import { createSlice } from "@reduxjs/toolkit";
import { User, UserState } from "./models";
import { getAll, update } from "./thunkActions";
import { Action } from "../shared/models";

const initialState: UserState = {
  users: [],
  user: undefined,
  isUserListLoading: false,
  isUpdateUserLoading: false,
};

const userSlice = createSlice({
  name: "User",
  initialState,
  reducers: {
    selectUser: (state, action: Action<User | undefined>) => {
      state.user = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder.addCase(getAll.pending, (state) => {
      state.users = [];
      state.isUserListLoading = true;
    });
    builder.addCase(getAll.rejected, (state) => {
      state.users = [];
      state.isUserListLoading = false;
    });
    builder.addCase(getAll.fulfilled, (state, action) => {
      state.users = action.payload;
      state.isUserListLoading = false;
    });
    builder.addCase(update.pending, (state) => {
      state.isUpdateUserLoading = true;
    });
    builder.addCase(update.rejected, (state) => {
      state.isUpdateUserLoading = false;
    });
    builder.addCase(update.fulfilled, (state, action) => {
      state.isUpdateUserLoading = false;
      state.user = action.payload
    });
  },
});

export default userSlice;
