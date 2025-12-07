import { gql } from "apollo-angular";

    export const GET_USERS = gql`
      query {
        users {
          id
          firstName
          lastName
          email
          isActive
        }
      }
    `;
    export const GET_USER_BY_ID = gql`
    query($id: UUID!) {
        userById (id: $id)
        {
            id 
            firstName
            lastName
            email
            isActive
        }
      }`;