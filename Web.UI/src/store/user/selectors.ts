import { createSelector } from "@reduxjs/toolkit";
import { RootState } from "../../store";

const selectState = (rs: RootState) => rs.user;
const selectUsers = createSelector([selectState], (state) => state.users);
const selectIsUserListLoading = createSelector([selectState], (state)=>state.isUserListLoading);
const selectIsUpdateUserLoading =createSelector([selectState], (state)=>state.isUpdateUserLoading);
const selectUser = createSelector([selectState], (state)=>state.user);

const userSelectors = {
  selectState,
  selectUsers,
  selectIsUserListLoading,
  selectIsUpdateUserLoading,
  selectUser,
};

export default userSelectors;
