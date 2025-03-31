export interface UserState {
    users: User[];
    isUserListLoading: boolean;
}

export interface User {
    id: number;
    firstName: string;
    lastName: string;
    description: string;
    email: string;
}