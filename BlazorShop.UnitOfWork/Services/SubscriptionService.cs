namespace BlazorShop.UnitOfWork.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubscriptionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<SubscriptionResponse> GetAll()
        {
            try
            {
                var result = _unitOfWork.SubscriptionRepository.GetAll();
                var subscriptions = _mapper.Map<List<SubscriptionResponse>>(result);
                return subscriptions;
            }
            catch (Exception ex)
            {
                return new List<SubscriptionResponse>
                {
                    new SubscriptionResponse
                    {
                        Error = "There was an error while getting the subscriptions... " + ex.Message ?? ex.InnerException.Message
                    }
                };
            }
        }

        public SubscriptionResponse Get(int id)
        {
            try
            {
                var result = _unitOfWork.SubscriptionRepository.Get(id);
                var subscription = _mapper.Map<SubscriptionResponse>(result);
                return subscription;
            }
            catch (Exception ex)
            {
                return new SubscriptionResponse
                {
                    Error = "There was an error while getting the subscription by id... " + ex.Message ?? ex.InnerException.Message
                };
            }
        }

        public RequestResponse AddSubscription(SubscriptionResponse subscription)
        {
            try
            {
                var entity = _unitOfWork.SubscriptionRepository.Get(subscription.Id);
                if (entity != null) throw new ArgumentNullException();

                entity = new Subscription
                {
                    Name = subscription.Name,
		            Price = subscription.Price,
		            Currency = subscription.Currency,
		            CurrencySymbol = subscription.CurrencySymbol,
		            ChargeType = subscription.ChargeType,
		            Options = subscription.Options,
                };

                _unitOfWork.SubscriptionRepository.Add(entity);
                _unitOfWork.Commit();
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error creating the subscription", ex));
            }
        }

        public RequestResponse UpdateSubscription(SubscriptionResponse subscription)
        {
            try
            {
                var entity = _unitOfWork.SubscriptionRepository.Get(subscription.Id);
                if (entity == null) throw new ArgumentNullException();

                entity.Name = subscription.Name;
                entity.Price = subscription.Price;
                entity.Currency = subscription.Currency;
                entity.CurrencySymbol = subscription.CurrencySymbol;
                entity.ChargeType = subscription.ChargeType;
                entity.Options = subscription.Options;

                _unitOfWork.SubscriptionRepository.Update(entity);
                _unitOfWork.Commit();
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error updating the subscription", ex));
            }
        }

        public RequestResponse DeleteSubscription(int id)
        {
            try
            {
                var entity = _unitOfWork.SubscriptionRepository.Get(id);
                if (entity == null) throw new ArgumentNullException();

                _unitOfWork.SubscriptionRepository.Delete(entity);
                _unitOfWork.Commit();
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error deleting the subscription", ex));
            }
        }
    }
}
