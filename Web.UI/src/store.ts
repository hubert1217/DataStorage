import { combineReducers, configureStore, ThunkAction } from "@reduxjs/toolkit";
import { UserState } from "./store/user/models";
import { Action } from "./store/shared/models";
import rootReducer from "./reducers";

const combinedReducers = combineReducers({
  ...rootReducer,
});

const store = configureStore({
  reducer: combinedReducers,
});

export interface RootState {
  user: UserState;
}

export type AppDispatch = typeof store.dispatch;
export type AppThunkAction<TPayload = any> = ThunkAction<
  Promise<void>,
  RootState,
  unknown,
  Action<TPayload>
>;

export default store;
