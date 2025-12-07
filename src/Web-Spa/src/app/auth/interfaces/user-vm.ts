export interface UserVm {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  isActive: boolean;
  password?: string | null;
}

export interface LoginVm {
  email: string;
  password: string;
}