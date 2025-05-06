export interface UserState extends UserLoadingState {
  users: User[];
  user: User | undefined;
}

interface UserLoadingState {
  isUserListLoading: boolean;
  isUpsertUserLoading: boolean;
  isDeleteUserLoading: boolean;
}

export interface User {
  id: number;
  firstName: string;
  lastName: string;
  description: string;
  email: string;
}
