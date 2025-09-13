import { Injectable } from '@angular/core';
import { Apollo, gql } from 'apollo-angular';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

export interface UserVm {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  isActive: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private apollo: Apollo) { }

  getUsers(): Observable<UserVm[]> {
    const GET_USERS = gql`
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

    return this.apollo
      .watchQuery<{ users: UserVm[] }>({ query: GET_USERS })
      .valueChanges
      .pipe(
        map(result => {
          console.log(result.data.users);
          return result.data.users;
        })
      );
  }
}
