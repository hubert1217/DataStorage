import { createSlice } from "@reduxjs/toolkit";
import { User, UserState } from "./models";
import { add, deleteUser, getAll, update } from "./thunkActions";
import { Action } from "../shared/models";

const initialState: UserState = {
  users: [],
  user: undefined,
  isUserListLoading: false,
  isUpsertUserLoading: false,
  isDeleteUserLoading: false,
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
      state.isUpsertUserLoading = true;
    });
    builder.addCase(update.rejected, (state) => {
      state.isUpsertUserLoading = false;
    });
    builder.addCase(update.fulfilled, (state, action) => {
      state.isUpsertUserLoading = false;
      state.user = action.payload;
      state.users = state.users.map((user) => {
        if (user.id === action.payload.id) {
          return action.payload;
        }
        return user;
      });
    });
    builder.addCase(add.pending, (state) => {
      state.isUpsertUserLoading = true;
    });
    builder.addCase(add.rejected, (state) => {
      state.isUpsertUserLoading = false;
    });
    builder.addCase(add.fulfilled, (state, action) => {
      state.isUpsertUserLoading = false;
      state.user = action.payload;
      state.users.push(action.payload);
      //state.users = [...state.users, action.payload];
    });
    builder.addCase(deleteUser.pending, (state) => {
      state.isDeleteUserLoading = true;
    });
    builder.addCase(deleteUser.rejected, (state) => {
      state.isDeleteUserLoading = false;
    });
    builder.addCase(deleteUser.fulfilled, (state, action) => {
      state.isDeleteUserLoading = false;
      state.users = state.users.filter((u) => u.id !== action.payload);
    });
  },
});

export default userSlice;
