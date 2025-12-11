import { gql } from "apollo-angular";

export const CREATE_USER = gql `
mutation register($userVm: UserInput!) {
  register(userVm: $userVm) {
    id
    firstName
    lastName
    email
    isActive
  }
}`;

export const LOGIN_USER = gql `
mutation loginComponent(userVm: LoginInput!)
{
    login($userVm: userVm);
    {
    }
};`